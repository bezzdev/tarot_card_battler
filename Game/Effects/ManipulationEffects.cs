using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class ShuffleField : Effect
    {
        public ShuffleField()
        {
            tooltip = "Shuffles the Opponent's Field";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Shuffled opponents field");


            int choice = Random.Shared.Next(0, 2);

            Card a = opponent.field.past.card;
            Card b = opponent.field.present.card;
            Card c = opponent.field.future.card;

            if (choice == 0)
            {
                opponent.field.past.card = b;
                opponent.field.present.card = c;
                opponent.field.future.card = a;
            }
            else
            {
                opponent.field.past.card = c;
                opponent.field.present.card = a;
                opponent.field.future.card = b;
            }

            opponent.field.past.SetCardPosition();
            opponent.field.present.SetCardPosition();
            opponent.field.future.SetCardPosition();
        }
    }
    public class ShuffleDiscard : Effect
    {
        public ShuffleDiscard()
        {
            tooltip = "Shuffles discarded cards back into deck";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player shuffled discard pile");
            List<Card> discardCards = player.discards.cards.ToList();
            CardList.Shuffle(discardCards);

            foreach (Card discard in discardCards)
            {
                player.discards.cards.Remove(discard);
                player.deck.Add(discard);
            }
            player.deck.SetCardPositions();
        }
    }
}
