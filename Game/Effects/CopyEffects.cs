using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class CopyOpposite : Effect
    {
        public CopyOpposite()
        {
            tooltip = "Copies opposite fields card effect";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            FieldSlot opponentSlot = opponent.field.slots[slot.number];
            Card opponentCard = opponentSlot.card;

            Effect opponentEffect = opponentCard.pastEffect;
            if (opponentSlot.number == 1)
            {
                opponentEffect = opponentCard.presentEffect;
            }
            else if (opponentSlot.number == 2)
            {
                opponentEffect = opponentCard.futureEffect;
            }

            if (opponentEffect is CopyOpposite)
            {
                if (player.debugName == "player") Console.WriteLine($"Skipping as magician is in both fields");
                return;
            }

            if (player.debugName == "player") Console.WriteLine($"Player copied effect of {opponentCard.name}");

            opponentEffect.triggerEffect(player, opponent, slot, card);
        }
    }

    public class RandomDiscardEffect : Effect
    {
        public RandomDiscardEffect()
        {
            tooltip = "Does a random effect from the discard pile";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Triggered random discard effect;");
            List<Card> discardCards = player.discards.cards.ToList();

            if (discardCards.Count > 0)
            {
                CardList.Shuffle(discardCards);

                Card discard = discardCards[0];
                Random rnd = new Random();
                int randomInt = rnd.Next(2);

                switch (randomInt)
                {
                    case 0:
                        discard.pastEffect.triggerEffect(player, opponent, slot, card);
                        break;
                    case 1:
                        discard.presentEffect.triggerEffect(player, opponent, slot, card);
                        break;
                    case 2:
                        discard.futureEffect.triggerEffect(player, opponent, slot, card);
                        break;
                    default:
                        discard.pastEffect.triggerEffect(player, opponent, slot, card);
                        break;
                }

                player.deck.SetCardPositions();
            }
        }
    }
}
