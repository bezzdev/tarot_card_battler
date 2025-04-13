using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{

    public class DamageEffect : Effect {
        public int damage;

        public override void showIndicator(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            EntityLayerManager.AddEntity(new IndicatorAnimation(card.position.x, card.position.y, -damage, new Color(230, 0, 0, 255)), IndicatorAnimation.defaultLayer);
        }
    }

    public class HealEffect : Effect {
        public int heal;

        public override void showIndicator(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            EntityLayerManager.AddEntity(new IndicatorAnimation(card.position.x, card.position.y, heal, new Color(0, 228, 0, 255)), IndicatorAnimation.defaultLayer);
        }
    }

    public class Damage : DamageEffect
    {
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

    public class RandomDamage : DamageEffect
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
            this.damage = damage;

            if (player.debugName == "player") Console.WriteLine($"Did random {damage} damage to {opponent.debugName}");
            opponent.playerStats.TakeDamage(damage);
        }
    }

    public class Heal : HealEffect
    {
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

    public class RandomHeal : HealEffect
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
            this.heal = heal;

            if (player.debugName == "player") Console.WriteLine($"Did random {heal} damage to {opponent.debugName}");
            player.playerStats.Heal(heal);
        }
    }

    public class StrengthHeal : HealEffect
    {
        public StrengthHeal()
        {
            tooltip = $"Heals amount equal to your strength";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            this.heal = player.playerStats.strength;
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

    public class ShieldDamage : DamageEffect
    {
        public ShieldDamage()
        {
            this.tooltip = $"Deals damage equal to shield ";
        }

        public override void showIndicator(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            this.damage = player.playerStats.shield;
            base.showIndicator(player, opponent, slot, card);
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            this.damage = player.playerStats.shield;
            if (player.debugName == "player") Console.WriteLine($"Player did {player.playerStats.shield} damage");
            opponent.playerStats.TakeDamage(player.playerStats.shield);
        }
    }

    public class ShieldHeal : HealEffect {
        public ShieldHeal()
        {
            this.tooltip = $"Heals damage equal to shield ";
        }

        public override void showIndicator(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            this.heal = player.playerStats.shield;
            base.showIndicator(player, opponent, slot, card);
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            this.heal = player.playerStats.shield;
            if (player.debugName == "player") Console.WriteLine($"Player did {player.playerStats.shield} damage");
            player.playerStats.Heal(player.playerStats.shield);
        }
    }

}
