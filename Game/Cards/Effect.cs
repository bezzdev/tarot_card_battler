using System.Diagnostics;

namespace tarot_card_battler.Game.Cards
{
    public class Effect
    {
        public string tooltip = "Generic tooltip";

        public virtual void triggerEffect(PlayerBoard player, PlayerBoard opponent) { } //param: playerBoard, param: opponentBoard

    }

    public class DamageEffect : Effect
    {
        public int damage;

        public DamageEffect(int damage)
        {
            this.tooltip = $"Does {damage} damage";
            this.damage = damage;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if (player.debugName == "player") Console.WriteLine($"Did {damage} damage to {opponent.debugName}");
            opponent.TakeDamage(damage);
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

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if (player.debugName == "player") Console.WriteLine($"Healed {heal} damage to {player.debugName}");
            player.Heal(heal);
        }
    }

    public class Draw : Effect
    {
        public Draw()
        {
            this.tooltip = tooltip;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
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

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if ((player.field.past.pastEffect is CopyOpposite) && (opponent.field.past.pastEffect is CopyOpposite))
            {
                if (player.debugName == "player") Console.WriteLine($"Skipping as magician is in both fields");
                return;
            }
            if ((player.field.present.presentEffect is CopyOpposite) && (opponent.field.present.presentEffect is CopyOpposite))
            {
                if (player.debugName == "player") Console.WriteLine($"Skipping as magician is in both fields");
                return;
            }
            if ((player.field.future.futureEffect is CopyOpposite) && (opponent.field.future.futureEffect is CopyOpposite))
            {
                if (player.debugName == "player") Console.WriteLine($"Skipping as magician is in both fields");
                return;
            }
            if (fieldIndex == 0)
            {
                if (player.debugName == "player") Console.WriteLine($"Player copied past effect of {opponent.field.past.name}");
                opponent.field.past.pastEffect.triggerEffect(opponent, player);
            }
            else if (fieldIndex == 1)
            {
                if (player.debugName == "player") Console.WriteLine($"Player copied present effect of {opponent.field.present.name}");
                opponent.field.past.presentEffect.triggerEffect(opponent, player);
            }
            else if (fieldIndex == 2)
            {
                if (player.debugName == "player") Console.WriteLine($"Player copied future effect of {opponent.field.future.name}");
                opponent.field.past.presentEffect.triggerEffect(opponent, player);
            }
            else
            {
                return;
            }
        }
    }

    public class Shield : Effect
    {
        public int shield;
        public Shield(int shield)
        {
            this.shield = shield;;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if (player.debugName == "player") Console.WriteLine($"Player added {shield} shield");
            player.Shield(shield);
        }
    }

    public class ShuffleField : Effect
    {
        public ShuffleField()
        {
            this.tooltip = "Randomises Opponent Field";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if (player.debugName == "player") Console.WriteLine($"Shuffled opponents field");
            Random random = new Random();

            int[] fieldOrder = [0, 1, 2];

            for (int i = 0; i < fieldOrder.Length - 1; ++i)
            {
                int r = random.Next(i, fieldOrder.Length);
                (fieldOrder[r], fieldOrder[i]) = (fieldOrder[i], fieldOrder[r]);
            }

            Card? placeholder = null;

            placeholder = opponent.field.past;

            opponent.field.past = opponent.field.present;

            opponent.field.present = opponent.field.future;

            opponent.field.future = placeholder;

            opponent.field.SetPastCardPosition();
            opponent.field.SetPresentCardPosition();
            opponent.field.SetFutureCardPosition();
        }
    }

    public class ShuffleDiscard : Effect
    {
        public ShuffleDiscard()
        {
            this.tooltip = "Shuffles discarded cards back into deck";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if (player.debugName == "player") Console.WriteLine($"Player shuffled discard pile");
            List<Card> discardCards = player.discards.cards.ToList();
            CardList.Shuffle(discardCards);

            foreach (Card card in discardCards)
            {
                player.discards.cards.Remove(card);
                player.deck.Add(card);
            }
            player.deck.SetCardPositions();
        }
    }
}