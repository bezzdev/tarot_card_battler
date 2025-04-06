using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.PlayArea
{
    public class FieldSlot
    {
        public static string[] slotNames = ["past", "present", "future"];

        public Field field;
        public int number;
        public Coord position = new Coord(0, 0);
        public Card? card = null;
        public float cardSpeed = 1400f;
        public bool faceup = true;
        public string debugName = "";

        public FieldSlot(int number)
        {
            this.number = number;

            this.debugName = slotNames[number];
        }

        public void SetCard(Card card)
        {
            this.card = card;
            card.faceup = true;
            SetCardPosition();
        }

        public void SetCardPosition(bool instant = false)
        {
            var world = GetWorldPosition();
            card.mover.SetPosition(world.x, world.y, instant ? float.MaxValue : cardSpeed);
        }

        public (double x, double y) GetWorldPosition()
        {
            return (field.position.x + position.x, field.position.y + position.y);
        }

        public void Update()
        {
            if (card != null)
            {
                card.Update();
            }
        }

        public void Render()
        {
            if (card != null)
            {
                card.Render();
            }
        }
    }
}
