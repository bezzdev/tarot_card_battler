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

    public class StrengthDeathCountdown : Effect
    {
        public StrengthDeathCountdown()
        {
            tooltip = "Give yourself 2 strength, in 3 turns you die";
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player played death present");
            player.playerStats.AddStrength(2);
            player.playerStats.deathCountdown = true;
            player.playerStats.countdown = 2;
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
            opponent.playerStats.countdown = 5;
        }
    }
    
    public class BuffAdjacentSlot : Effect
    {
        public int slotBuffed;
        public int buff;
        public BuffAdjacentSlot(int slot, int buff)
        {
            this.slotBuffed = slot;
            this.buff = buff;
            string slotName = "past";
            if(slot == 1) {slotName = "present";}
            if(slot == 2) {slotName = "future";}
            tooltip = $"Buffs card in the {slotName} slot by {buff}";
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player buffed slot {slotBuffed + 1}");

            FieldSlot buffedSlot = player.field.slots[slotBuffed];
            buffedSlot.card.cardBuff = buff;
        }
    }

    public class DebuffOppositeSlot : Effect
    {
        public int slotBuffed;
        public int buff;
        public DebuffOppositeSlot(int slot, int buff)
        {
            this.slotBuffed = slot;
            this.buff = buff;
            string slotName = "past";
            if(slot == 1) {slotName = "present";}
            if(slot == 2) {slotName = "future";}
            tooltip = $"Debuffs opposite {slotName} slot by {buff}";
        }
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if (player.debugName == "player") Console.WriteLine($"Player debuffed slot {slotBuffed + 1}");
            FieldSlot buffedSlot = opponent.field.slots[slotBuffed];
            buffedSlot.card.cardBuff = buff;
        }
    }
}