using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Cards
{
    public class Effect
    {
        public string tooltip = "Generic tooltip";

        public virtual void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card) { }

    }

    public class DamageEffect : Effect
    {
        public int damage;

        public DamageEffect(int damage)
        {
            this.tooltip = $"Does {damage} damage";
            this.damage = damage;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Did {damage} damage to {opponent.debugName}");
            opponent.playerStats.TakeDamage(damage);
        }
    }

    public class RandomDamage : Effect
    {
        private int min;
        private int max;
        public RandomDamage(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.tooltip = $"Does {min}-{max} random damage";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int damage = Random.Shared.Next(min, max + 1);

            if (player.debugName == "player") Console.WriteLine($"Did random {damage} damage to {opponent.debugName}");
            opponent.playerStats.TakeDamage(damage);
        }
    }

    public class Heal : Effect
    {
        public int heal;

        public Heal(int heal)
        {
            this.tooltip = $"Heals {heal} damage";
            this.heal = heal;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Healed {heal} damage to {player.debugName}");
            player.playerStats.Heal(heal);
        }
    }

    public class RandomHeal : Effect
    {
        private int min;
        private int max;
        public RandomHeal(int min, int max)
        {
            this.min = min;
            this.max = max;

            this.tooltip = $"Heals {min}-{max} random amount";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int heal = Random.Shared.Next(min, max + 1);

            if (player.debugName == "player") Console.WriteLine($"Did random {heal} damage to {opponent.debugName}");
            opponent.playerStats.Heal(heal);
        }
    }

    public class Draw : Effect
    {
        public Draw()
        {
            this.tooltip = "Draw 1 extra card next turn";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player drew 1 card");
        }
    }

    public class Countdown : Effect
    {

    }

    public class BlockOpponentEffect : Effect
    {

    }

    public class CopyOpposite : Effect
    {
        int fieldIndex;
        public CopyOpposite(int index)
        {
            this.fieldIndex = index;
            this.tooltip = "Copies opposite fields card effect";
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

    public class Shield : Effect
    {
        public int shield;
        public Shield(int shield)
        {
            this.shield = shield; ;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player added {shield} shield");
            player.playerStats.Shield(shield);
        }
    }

    public class ShuffleField : Effect
    {
        public ShuffleField()
        {
            this.tooltip = "Shuffles the Opponent's Field";
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
            } else
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
            this.tooltip = "Shuffles discarded cards back into deck";
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

    public class RandomDiscardEffect : Effect
    {
        public RandomDiscardEffect()
        {
            this.tooltip = "Does a random effect from the discard pile";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Triggered random discard effect;");
            List<Card> discardCards = player.discards.cards.ToList();
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