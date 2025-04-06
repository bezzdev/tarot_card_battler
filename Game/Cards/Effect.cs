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

        public DamageEffect(int damage, string tooltip)
        {
            this.tooltip = tooltip;
            this.damage = damage;
        }
    
        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            opponent.TakeDamage(damage);
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