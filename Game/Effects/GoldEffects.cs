using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class AddGold : Effect
    {
        public int gold;
        public AddGold(int gold)
        {
            this.gold = gold;
            tooltip = $"Adds {gold} gold";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Added {gold} gold");
            player.playerStats.AddGold(gold);
        }
    }

    public class StealOpponentGold : Effect
    {
        public int gold;
        public StealOpponentGold(int gold)
        {
            this.gold = gold;
            tooltip = $"Stole {gold} gold from opponent";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Stole {gold} gold from opponent");
            player.playerStats.AddGold(gold);
            opponent.playerStats.RemoveGold(gold);
        }
    }


    public class DamageGoldAmount : Effect
    {
        public DamageGoldAmount()
        {
            tooltip = $"Does damage equal to gold";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Did {player.playerStats.gold} damage");
            opponent.playerStats.TakeDamage(player.playerStats.gold);
        }
    }


    public class HealGoldAmount : Effect
    {
        public HealGoldAmount()
        {
            tooltip = $"Heals amount equal to gold";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Healed {player.playerStats.gold} damage");
            opponent.playerStats.Heal(player.playerStats.gold);
        }
    }

}