using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.PlayArea
{
    public class Hand
    {
        public Coord position = new Coord(0, 0);
        public List<Card> cards = new List<Card>();

        public double cardSpacing = 150;
        public float cardSpeed = 1400f;
        public bool faceup = true;

        public void Update()
        {
            foreach (Card card in cards)
            {
                card.Update();
            }
        }
        public void Add(Card card)
        {
            cards.Add(card);
            card.faceup = faceup;
        }

        public void SetCardPositions(bool instant = false)
        {
            double width = (cards.Count - 1) * cardSpacing;

            for (int i = 0; i < cards.Count; i++)
            {
                SetCardPosition(cards[i], instant);
            }
        }

        public void SetCardPosition(Card card, bool instant = false)
        {
            double width = (cards.Count - 1) * cardSpacing;
            int i = cards.IndexOf(card);
            double goalX = position.x + -width / 2 + i * cardSpacing;
            double goalY = position.y;

            cards[i].mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void Render()
        {
            foreach (Card card in cards) { card.Render(); }
        }
    }
}