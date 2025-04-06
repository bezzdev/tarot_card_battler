using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.Effects
{
    public class Effect
    {
        public string tooltip = "Generic tooltip";

        public virtual void triggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card) { }

    }

    public class Draw : Effect
    {
        public Draw()
        {
            tooltip = "Draw 1 extra card next turn";
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
}