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
        public int heal;

        public Heal(int heal, string tooltip)
        {
            this.tooltip = tooltip;
            this.heal = heal;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            player.Heal(heal);
        }
    }

    public class Draw : Effect
    {
        public Draw(string tooltip)
        {
            this.tooltip = tooltip;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {

        }
    }

    public class Countdown : Effect
    {

    }

    public class BlockOpponentEffect : Effect
    {

    }

    public class Sheild : Effect
    {
        public int shield;
        public Sheild(int shield, string tooltip)
        {
            this.shield = shield;
            this.tooltip = tooltip;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
            player.Shield(shield);
        }
    }

    public class Shuffle : Effect
    {
        public Shuffle(string tooltip)
        {
            this.tooltip = tooltip;
        }

        public override void triggerEffect(PlayerBoard player, PlayerBoard opponent)
        {
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