using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_card_battler.Game.Cards
{
    public static class CardList
    {
        public static List<Card> GetAllCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card("Card Draft"));
            return cards;
        }
    }
}
