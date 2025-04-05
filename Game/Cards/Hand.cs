using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Core;

namespace tarot_card_battler.Game.Cards
{
    public class Hand
    {
        public Coord position = new Coord(0, 0);
        public List<Card> cards = new List<Card>();

        public double cardSpacing = 160;
        public float cardSpeed = 1000f;

        public void Update()
        {
            foreach(Card card in cards)
            {
                card.Update();
            }
        }

        public void SetCardPositions(bool instant = false)
        {
            double width = (cards.Count - 1) * cardSpacing;

            for (int i = 0; i < cards.Count; i++)
            {
                double goalX = position.x + (-width / 2) + (i * cardSpacing);
                double goalY = position.y;

                cards[i].mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
            }
        }

        public void Render()
        {
            foreach (Card card in cards) { card.Render(); }
        }
    }
}