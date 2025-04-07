using System.Numerics;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.PlayArea
{
    public class Field
    {
        public PlayerBoard player;

        public FieldSlot past = new FieldSlot(0);
        public FieldSlot present = new FieldSlot(1);
        public FieldSlot future = new FieldSlot(2);

        public List<FieldSlot> slots = new List<FieldSlot>();
        public Coord position = new Coord(0, 0);
        public float cardSpeed = 2000f;

        public Field(PlayerBoard player)
        {
            this.player = player;

            past.field = this;
            past.position.x = -170;

            present.field = this;
            present.position.x = 0;

            future.field = this;
            future.position.x = 170;

            slots.Add(past);
            slots.Add(present);
            slots.Add(future);
        }

        public void Update()
        {
            past.Update();
            present.Update();
            future.Update();
        }

        public void SetPastCard(Card card)
        {
            past.SetCard(card);
        }


        public void SetPresentCard(Card card)
        {
            present.SetCard(card);
        }

        public void SetFutureCard(Card card)
        {
            future.SetCard(card);
        }


        public void Render()
        {
            past.Render();
            present.Render();
            future.Render();
        }
    }
}
