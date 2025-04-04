using Raylib_cs;

namespace tarot_card_battler.Game.Cards
{

    public class Card
    {
        public Texture2D cardArt;
        public string name;
        public string number;

        public Effect pastEffect;
        public Card(string name)
        {
            this.name = name;
        }
        public virtual void TriggerPastEffect()
        {
            pastEffect.triggerEffect();
        }

        public virtual void TriggerPresentEffect()
        {
            pastEffect.triggerEffect();
        }

        public virtual void TriggerFutureEffect()
        {
            pastEffect.triggerEffect();
        }
    }
}