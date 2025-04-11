using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Effects;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Cards
{

    public class Card
    {
        public Texture2D cardArt;
        public Texture2D cardBack;
        public string name;
        public int number;

        public Effect pastEffect;
        public Effect presentEffect;
        public Effect futureEffect;

        // state
        public bool faceup = true;
        public Coord position;
        public Mover mover;
        public PlayerBoard owner;
        public int slotIndex = -1;
        public bool isBuffed = false;

        public Card(string name, int number, Texture2D cardArt)
        {
            this.name = name;
            this.number = number;
            this.cardArt = cardArt;
            cardBack = References.Back_Plain;
            position = new Coord(-400, 0); // off screen
            this.mover = new Mover(position);

            pastEffect = new Damage(1);
            presentEffect = new Damage(2);
            futureEffect = new Damage(3);
        }

        public Card Clone()
        {
            Card card = new Card(name, number, cardArt)
            {
                pastEffect = pastEffect,
                presentEffect = presentEffect,
                futureEffect = futureEffect
            };
            return card;
        }

        public void Update()
        {
            mover.Update();
        }

        public void Render()
        {
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            float rotation = 0f;
            float scale = 1f;
            
            float width = cardArt.Width * scale;
            float height = cardArt.Height * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height/ 2);
            
            if (faceup)
            {
                Raylib.DrawTextureEx(cardArt, new System.Numerics.Vector2(x, y), rotation, scale, Color.White);
            } else
            {
                Raylib.DrawTextureEx(cardBack, new System.Numerics.Vector2(x, y), rotation, scale, Color.White);
            }
        }
        public virtual void TriggerEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot)
        {
            if (slot.number == 0)
                this.TriggerPastEffect(slot.field.player, slot.field.player.opponent, slot, this);
            else if (slot.number == 1)
                this.TriggerPresentEffect(slot.field.player, slot.field.player.opponent, slot, this);
            else
                this.TriggerFutureEffect(slot.field.player, slot.field.player.opponent, slot, this);
        }

        public virtual void TriggerPastEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if(opponent.field.slots[slot.number].isLocked){
                // ANIMATION?
            } {
                pastEffect.triggerEffect(player, opponent, slot, card);
                opponent.field.slots[slot.number].isLocked = false;
            }
        }

        public virtual void TriggerPresentEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if(opponent.field.slots[slot.number].isLocked){
                // ANIMATION?
            } {
                presentEffect.triggerEffect(player, opponent, slot, card);
                opponent.field.slots[slot.number].isLocked = false;
            }
        }

        public virtual void TriggerFutureEffect(PlayerBoard player, PlayerBoard opponent, FieldSlot slot, Card card)
        {
            if(opponent.field.slots[slot.number].isLocked){
                // ANIMATION?
            } {
                futureEffect.triggerEffect(player, opponent, slot, card);
                opponent.field.slots[slot.number].isLocked = false;
            }
        }
        public virtual bool IsInBounds(double x, double y)
        {
            int halfWidth = cardArt.Width / 2;
            int halfHeight = cardArt.Height / 2;
            if (x > position.x - halfWidth && x < position.x + halfWidth && y > position.y - halfHeight && y < position.y + halfHeight){
                    return true;
            }
            return false; 
        }
    }
}