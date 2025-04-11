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
            resolveDuration = 0f;
            earlyResolveDuration = 1f;
        }

        public override void triggerEarlyEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Shuffled opponents field");


            int choice = Random.Shared.Next(0, 2);

            Card a = opponent.field.past.card;
            Card b = opponent.field.present.card;
            Card c = opponent.field.future.card;

            if (choice == 0)
            {
                opponent.field.past.SetCard(b);
                opponent.field.present.SetCard(c);
                opponent.field.future.SetCard(a);
            }
            else
            {
                opponent.field.past.SetCard(c);
                opponent.field.present.SetCard(a);
                opponent.field.future.SetCard(b);
            }

            opponent.field.past.SetCardPosition();
            opponent.field.present.SetCardPosition();
            opponent.field.future.SetCardPosition();
        }
    }

    public class SwapAboveWithRandomFromHand : Effect
    {
        public SwapAboveWithRandomFromHand()
        {
            tooltip = "Swaps the above card with a random card from the opponents hand";
            resolveDuration = 0f;
            earlyResolveDuration = 1f;
        }

        public override void triggerEarlyEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            FieldSlot opponentSlot = opponent.field.slots[slot.number];
            Card opponentCard = opponentSlot.card;

            Hand opponentHand = opponent.hand;
            if (opponentCard != null && opponentHand.cards.Count > 0)
            {
                int choice = Random.Shared.Next(0, opponentHand.cards.Count);
                Card cardChoice = opponentHand.cards[choice];
                
                opponentSlot.RemoveCard();
                opponentHand.Add(opponentCard);

                opponentHand.cards.Remove(cardChoice);
                opponentSlot.SetCard(cardChoice);

                opponentHand.SetCardPositions();
                if (player.debugName == "player") Console.WriteLine($"Swapping opponents {opponentSlot.debugName} card with a random card from their hand");
            }
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

    public class Nullify : Effect
    {
        public Nullify()
        {
            tooltip = "Blocks opposite cards effect";
            resolveDuration = 0f;
            earlyResolveDuration = 1f;
        }
        public override void triggerEarlyEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player nullified {slot.debugName}");
            opponent.field.slots[slot.number].isLocked = true;
        }
    }
}
