using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.GameLoop
{
    public class DiscardState : State
    {
        private Board board;
        private Delay delay = new Delay(1f);
        private State nextState;

        private Delay burnDelay = new Delay(0.5f);
        private List<CardBurnEffect> burnAnimations = new List<CardBurnEffect>();

        public DiscardState(Board board, State nextState)
        {
            this.board = board;
            this.nextState = nextState;
        }
        public override void Update()
        {
            burnDelay.Update(References.delta);
            if (burnDelay.CompletedOnce())
            {
                Discard();
            }

            delay.Update(References.delta);

            if (delay.Completed())
            {
                stateMachine.SetState(nextState);
            }
        }

        int burnNumber = 0;
        int GetBurnNumber()
        {
            burnNumber = (burnNumber + 1) % 6;
            return burnNumber;
        }
        public override void OnEnter()
        {

            AudioReferences.PlaySound(AudioReferences.cardBurn);
            
            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past != null) { 
                    Card past = player.field.past.card;
                    CardBurnEffect burn = new CardBurnEffect(past.position.x, past.position.y, GetBurnNumber());
                    burnAnimations.Add(burn);
                    EntityLayerManager.AddEntity(burn, CardBurnEffect.defaultLayer);
                }

                if (player.field.present != null)
                {
                    Card present = player.field.present.card;
                    CardBurnEffect burn = new CardBurnEffect(present.position.x, present.position.y, GetBurnNumber());
                    burnAnimations.Add(burn);
                    EntityLayerManager.AddEntity(burn, CardBurnEffect.defaultLayer);
                }

                if (player.field.future != null)
                {
                    Card future = player.field.future.card;
                    CardBurnEffect burn = new CardBurnEffect(future.position.x, future.position.y, GetBurnNumber());
                    burnAnimations.Add(burn);
                    EntityLayerManager.AddEntity(burn, CardBurnEffect.defaultLayer);
                }
            }
        }

        public void Discard()
        {
            foreach (CardBurnEffect burn in burnAnimations)
            {
                burn.end = true;
            }
            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past != null)
                {
                    Card pastCard = player.field.past.card;
                    player.field.past.RemoveCard();
                    player.discards.Add(pastCard);
                }

                if (player.field.present != null)
                {
                    Card presentCard = player.field.present.card;
                    player.field.present.RemoveCard();
                    player.discards.Add(presentCard);
                }

                if (player.field.future != null)
                {
                    Card futureCard = player.field.future.card;
                    player.field.future.RemoveCard();
                    player.discards.Add(futureCard);
                }

                player.discards.SetCardPositions();
            }
        }
    }
}
