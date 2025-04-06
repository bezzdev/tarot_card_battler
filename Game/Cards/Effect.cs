using System.Diagnostics;

namespace tarot_card_battler.Game.Cards
{
    public class Effect
    {
        public string tooltip = "Generic tooltip";

        public virtual void triggerEffect(PlayerBoard player, PlayerBoard opponent) {} //param: playerBoard, param: opponentBoard

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
            if(player.debugName == "player") Console.WriteLine($"Did {damage} damage to {opponent.debugName}");
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
            if(player.debugName == "player") Console.WriteLine($"Healed {heal} damage to {player.debugName}");
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
         if(player.debugName == "player") Console.WriteLine($"Player drew 1 card");
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
            if(!(opponent.field.past.pastEffect is CopyOpposite)){
                return;
            }
            if(fieldIndex == 0){
                if(player.debugName == "player") Console.WriteLine($"Player copied past effect of {opponent.field.past.name}");
                opponent.field.past.pastEffect.triggerEffect(opponent, player);
            } else if(fieldIndex == 1){
                if(player.debugName == "player") Console.WriteLine($"Player copied present effect of {opponent.field.past.name}");
                opponent.field.past.presentEffect.triggerEffect(opponent, player);
            } else if(fieldIndex == 2){
                if(player.debugName == "player") Console.WriteLine($"Player copied future effect of {opponent.field.past.name}");
                opponent.field.past.presentEffect.triggerEffect(opponent, player);
            } else {
                return;
            }
        }
    }

    public class Shield : Effect
    {
        public int shield;
        public Shield(int shield)
        {
            this.shield = shield;
            this.tooltip = tooltip;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if(player.debugName == "player") Console.WriteLine($"Player added {shield} shield");
            player.Shield(shield);
        }
    }

    public class Shuffle : Effect
    {
        public Shuffle()
        {
            this.tooltip = "Shuffles discarded cards back into deck";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            if(player.debugName == "player") Console.WriteLine($"Player shuffled discard pile");
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