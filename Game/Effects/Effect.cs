using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class Effect
    {
        public string tooltip = "Generic tooltip";

        public virtual void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card) { }
        public virtual string GetTooltip()
        {
            return tooltip;
        }

    }

    public class Draw : Effect
    {
        public Draw()
        {
            tooltip = "Draw 1 extra card next turn";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player draws 1 extra card next turn");
            player.playerStats.drawPerTurn = 4;
        }
    }

    public class DeathCountdown : Effect
    {
        public DeathCountdown()
        {
            tooltip = "Give opponent 99 shield, in 5 turns win the game";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player played death");
            opponent.playerStats.Shield(99);
            opponent.playerStats.deathCountdown = true;
        }
    }

    public class BlockOpponentEffect : Effect
    {

    }

    public class BuffAdjacentSlot : Effect
    {
        public int slotBuffed;
        public BuffAdjacentSlot(int slot)
        {
            this.slotBuffed = slot;
            string slotName = "past";
            if(slot == 1) {slotName = "present";}
            if(slot == 2) {slotName = "future";}
            tooltip = $"Buffs card in the {slotName} slot";
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player buffed slot {slotBuffed + 1}");

            FieldSlot buffedSlot = player.field.slots[slotBuffed];
            buffedSlot.card.isBuffed = true;
        }
    }
}