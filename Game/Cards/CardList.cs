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
            cards.Add(new Card("Card Draft", References.sampleTexture) { pos = new Core.Coord(6, 2)});
            cards.Add(new Card("Card Draft", References.sampleTexture) { pos = new Core.Coord(6, 6) });
            cards.Add(new Card("Card Draft", References.sampleTexture) { pos = new Core.Coord(6, 5) });
            cards.Add(new Card("Card Draft", References.sampleTexture) { pos = new Core.Coord(6, 4) });
            return cards;
        }
    }
}
