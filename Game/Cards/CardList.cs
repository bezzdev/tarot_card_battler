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
            cards.Add(new Card("Card Draft 1", References.sampleTexture));
            cards.Add(new Card("Card Draft 2", References.sampleTexture));
            cards.Add(new Card("Card Draft 3", References.sampleTexture));
            cards.Add(new Card("Card Draft 4", References.sampleTexture));
            cards.Add(new Card("Card Draft 5", References.sampleTexture));
            cards.Add(new Card("Card Draft 6", References.sampleTexture));
            cards.Add(new Card("Card Draft 7", References.sampleTexture));
            cards.Add(new Card("Card Draft 8", References.sampleTexture));
            cards.Add(new Card("Card Draft 9", References.sampleTexture));
            cards.Add(new Card("Card Draft 10", References.sampleTexture));
            cards.Add(new Card("Card Draft 11", References.sampleTexture));
            cards.Add(new Card("Card Draft 12", References.sampleTexture));
            cards.Add(new Card("Card Draft 13", References.sampleTexture));
            cards.Add(new Card("Card Draft 14", References.sampleTexture));
            cards.Add(new Card("Card Draft 15", References.sampleTexture));
            cards.Add(new Card("Card Draft 16", References.sampleTexture));
            cards.Add(new Card("Card Draft 17", References.sampleTexture));
            cards.Add(new Card("Card Draft 18", References.sampleTexture));
            cards.Add(new Card("Card Draft 19", References.sampleTexture));
            cards.Add(new Card("Card Draft 20", References.sampleTexture));
            return cards;
        }
    }
}
