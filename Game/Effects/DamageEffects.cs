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
            tooltip = $"Does {min}-{max} random damage";
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
            tooltip = $"Heals {heal} damage";
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

            tooltip = $"Heals {min}-{max} random amount";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            int heal = Random.Shared.Next(min, max + 1);

            if (player.debugName == "player") Console.WriteLine($"Did random {heal} damage to {opponent.debugName}");
            opponent.playerStats.Heal(heal);
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

}
