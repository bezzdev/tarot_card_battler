using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class Damage : Effect
    {
        public int damage;

        public Damage(int damage)
        {
            tooltip = $"Does {damage} damage";
            this.damage = damage;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int totalDamage = damage + player.playerStats.strength - player.playerStats.weakness + card.cardBuff;
            if (player.debugName == "player") Console.WriteLine($"Did {totalDamage} damage to {opponent.debugName} (strength: {player.playerStats.strength})(weakness: {opponent.playerStats.weakness})");
            opponent.playerStats.TakeDamage(totalDamage);
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
            tooltip = $"Does {min}-{max} random damage";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int damage = Random.Shared.Next(min, max + 1) + card.cardBuff;

            if (player.debugName == "player") Console.WriteLine($"Did random {damage} damage to {opponent.debugName}");
            opponent.playerStats.TakeDamage(damage);
        }
    }

    public class Heal : Effect
    {
        public int heal;

        public Heal(int heal)
        {
            tooltip = $"Heals {heal} damage";
            this.heal = heal;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Healed {heal + card.cardBuff} damage to {player.debugName}");
            player.playerStats.Heal(heal + card.cardBuff);
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

            tooltip = $"Heals {min}-{max} random amount";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int heal = Random.Shared.Next(min, max + 1) + card.cardBuff;

            if (player.debugName == "player") Console.WriteLine($"Did random {heal} damage to {opponent.debugName}");
            player.playerStats.Heal(heal);
        }
    }

    public class StrengthHeal : Effect
    {
        public StrengthHeal()
        {

            tooltip = $"Heals amount equal to your strength";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Did random {player.playerStats.strength} damage to {opponent.debugName}");
            player.playerStats.Heal(player.playerStats.strength + card.cardBuff);
        }
    }

    public class Shield : Effect
    {
        public int shield;
        public Shield(int shield)
        {
            this.shield = shield;
            this.tooltip = $"Adds {shield} shield";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player added {shield} shield");
            player.playerStats.Shield(shield + card.cardBuff);
        }
    }

    public class Strength : Effect
    {
        public Strength()
        {
            this.tooltip = $"Adds 1 strength";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player added 1 strength");
            player.playerStats.AddStrength(1 + card.cardBuff);
        }
    }

    public class Weakness : Effect
    {
        public Weakness()
        {
            this.tooltip = $"Adds 1 weakness";
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player added 1 weakness to opponent");
            opponent.playerStats.AddWeakness(1 + card.cardBuff);
        }
    }

    public class ShieldDamage : Effect
    {
         public ShieldDamage()
        {
            this.tooltip = $"Deals damage equal to shield ";
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player did {player.playerStats.shield} damage");
            opponent.playerStats.TakeDamage(player.playerStats.shield);
        }
    }

}
