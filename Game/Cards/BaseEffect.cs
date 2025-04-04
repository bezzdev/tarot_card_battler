namespace tarot_card_battler.Game.Cards
{

    public class Effect
    {

        public virtual void triggerEffect() { } //param: playerBoard, param: opponentBoard

    }

    public class DamageEffect : Effect
    {
        public override void triggerEffect()
        {

        }
    }

    public class Heal : Effect
    {

    }

    public class Draw : Effect
    {

    }

    public class Countdown : Effect
    {

    }

    public class BlockOpponentEffect : Effect
    {

    }

    public class Sheild : Effect
    {

    }

    public class Shuffle : Effect
    {

    }
}