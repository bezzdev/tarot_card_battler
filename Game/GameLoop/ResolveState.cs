using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.Effects;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class ResolveState : State
    {
        private Board board;

        public const float earlyPingDelay = 0.1f;
        public const float earlyEffectDelay = 0.2f;

        private Delay earlyCardPingTimer = new Delay(earlyPingDelay);
        private Delay earlyEffectTimer = new Delay(earlyEffectDelay + earlyEffectDelay);
        private Delay earlyEffectResolveTimer = new Delay(0f);

        public const float pingDelay = 0.1f;
        public const float effectDelay = 0.2f;

        private Delay cardPingTimer = new Delay(pingDelay);
        private Delay effectTimer = new Delay(effectDelay + pingDelay);
        private Delay effectResolveTimer = new Delay(0f);

        private Delay endTimer = new Delay(1f);

        private List<FieldSlot> earlyEffectSlots = new List<FieldSlot>();
        private List<FieldSlot> effectSlots = new List<FieldSlot>();

        public ResolveState(Board board)
        {
            this.board = board;
        }

        public override void OnEnter()
        {
            // setup slots
            effectSlots.Add(board.players[0].field.past);
            effectSlots.Add(board.players[1].field.past);
            effectSlots.Add(board.players[0].field.present);
            effectSlots.Add(board.players[1].field.present);
            effectSlots.Add(board.players[0].field.future);
            effectSlots.Add(board.players[1].field.future);
            earlyEffectSlots.AddRange(effectSlots);

            // death countdown
            if (board.player.playerStats.deathCountdown == true)
            {
                board.player.playerStats.countdown -= 1;
                Console.WriteLine($"Player countdown is {board.player.playerStats.countdown}");
            }
            else if (board.players[1].playerStats.deathCountdown == true)
            {
                board.players[1].playerStats.countdown -= 1;
                Console.WriteLine($"Opponent countdown is {board.players[0].playerStats.countdown}");
            }

            if (board.player.playerStats.countdown == 0)
            {
                board.player.playerStats.health = 0;
            }
            else if (board.players[1].playerStats.countdown == 0)
            {
                board.players[1].playerStats.health = 0;
            }

            // check game state
            CheckWinner();
        }

        public void HandleEarlyEffects()
        {
            FieldSlot slot = earlyEffectSlots[0];
            if (slot.card != null)
            {
                Effect effect = slot.card.GetEffect(slot.field.player, slot.field.player.opponent, slot);
                float earlyResolveTime = effect.earlyResolveDuration;
                bool hasEarlyEffect = earlyResolveTime > 0f;

                earlyResolveTime = MathF.Max(earlyResolveTime, 0.2f);

                if (earlyResolveTime > 0f)
                {
                    earlyCardPingTimer.Update(References.delta);
                    if (earlyCardPingTimer.CompletedOnce())
                    {
                        if (slot.card != null)
                        {
                            if (hasEarlyEffect)
                            {
                                EntityLayerManager.AddEntity(new EarlyCardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                            } else
                            {
                                EntityLayerManager.AddEntity(new NoEffectAnimation(slot.card.position.x, slot.card.position.y, new Color(1f, 0f, 0f, 0.6f)), NoEffectAnimation.defaultLayer);
                            }
                        }
                    }

                    earlyEffectTimer.Update(References.delta);
                    if (earlyEffectTimer.CompletedOnce())
                    {
                        if (slot.card != null)
                        {
                            earlyEffectResolveTimer.SetGoal(earlyResolveTime);
                            effect.triggerEarlyEffect(slot.field.player, slot.field.player.opponent, slot, slot.card);
                        }
                    }

                    earlyEffectResolveTimer.Update(References.delta);

                    if (earlyCardPingTimer.Completed() && earlyEffectTimer.Completed() && earlyEffectResolveTimer.Completed())
                    {
                        earlyEffectSlots.Remove(slot);
                        earlyCardPingTimer.Reset();
                        earlyEffectTimer.Reset();
                        earlyEffectResolveTimer.Reset();

                        if (CheckWinner())
                        {
                            return;
                        }
                    }
                    return;
                }
            }

            // no card in this slot or no early effect
            earlyEffectSlots.Remove(slot);
        }

        public void HandleEffects()
        {
            FieldSlot slot = effectSlots[0];
            if (slot.card != null)
            {
                Effect effect = slot.card.GetEffect(slot.field.player, slot.field.player.opponent, slot);
                float resolveTime = effect.resolveDuration;
                bool hasEffect = resolveTime > 0f;

                resolveTime = MathF.Max(resolveTime, 0.2f);

                if (resolveTime > 0f)
                {
                    cardPingTimer.Update(References.delta);
                    if (cardPingTimer.CompletedOnce())
                    {
                        if (slot.card != null)
                        {
                            if (!slot.isLocked)
                            {
                                if (hasEffect)
                                {
                                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                                }
                                else
                                {
                                    EntityLayerManager.AddEntity(new NoEffectAnimation(slot.card.position.x, slot.card.position.y, new Color(1f, 0.8f, 0f, 0.6f)), NoEffectAnimation.defaultLayer);
                                }
                            }
                            else
                            {
                                // lock animation
                                EntityLayerManager.AddEntity(new NegatedAnimation(slot.card.position.x, slot.card.position.y), NegatedAnimation.defaultLayer);
                            }
                        }
                    }

                    effectTimer.Update(References.delta);
                    if (effectTimer.CompletedOnce())
                    {
                        if (slot.card != null)
                        {
                            effectResolveTimer.SetGoal(0);
                            if (slot.isLocked)
                            {
                                slot.isLocked = false;
                            }
                            else
                            {
                                effectResolveTimer.SetGoal(resolveTime);
                                effect.triggerEffect(slot.field.player, slot.field.player.opponent, slot, slot.card);
                            }
                        }
                    }

                    effectResolveTimer.Update(References.delta);

                    if (cardPingTimer.Completed() && effectTimer.Completed() && effectResolveTimer.Completed())
                    {
                        effectSlots.Remove(slot);
                        cardPingTimer.Reset();
                        effectTimer.Reset();
                        effectResolveTimer.Reset();

                        if (CheckWinner())
                        {
                            return;
                        }
                    }
                    return;
                }
            }

            // no card in this slot or no effect
            effectSlots.Remove(slot);
        }
        
        public override void Update()
        {
            if (earlyEffectSlots.Count > 0)
            {
                HandleEarlyEffects();
            }
            else if (effectSlots.Count > 0)
            {
                HandleEffects();
            }
            else
            {
                endTimer.Update(References.delta);

                if (endTimer.CompletedOnce())
                {
                    // player game over
                    if (board.player.playerStats.health == 0)
                    {
                        stateMachine.SetState(new GameOverState(board));
                    }
                    if(!CheckWinner())
                    {
                        stateMachine.SetState(new DiscardState(board, new DrawState(board)));
                    }
                }
            }
        }
        public bool CheckWinner()
        {
            // player game over
            if (board.player.playerStats.health == 0)
            {
                stateMachine.SetState(new GameOverState(board));
                return true;
            }
            // opponent game over, player wins
            else if (board.players[1].playerStats.health == 0)
            {
                EntityLayerManager.AddEntity(new OpponentDeathAnimation(), OpponentDeathAnimation.defaultLayer);
                stateMachine.SetState(new DiscardState(board, new GameWinState(board)));
                return true;
            }
            return false;
        }
    }
}
