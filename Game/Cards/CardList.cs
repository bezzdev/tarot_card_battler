using System;
using System.Collections.Generic;
using System.IO;
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

            cards.Add(new Card("The_Fool", References.The_Fool));
            cards.Add(new Card("The_Magician", References.The_Magician));
            cards.Add(new Card("The_High_Priestess", References.The_High_Priestess));
            cards.Add(new Card("The_Empress", References.The_Empress));
            cards.Add(new Card("The_Emperor", References.The_Emperor));
            cards.Add(new Card("The_Hierophant", References.The_Hierophant));
            cards.Add(new Card("The_Lovers", References.The_Lovers));
            cards.Add(new Card("The_Chariot", References.The_Chariot));
            cards.Add(new Card("Strength", References.Strength));
            cards.Add(new Card("The_Hermit", References.The_Hermit));
            cards.Add(new Card("Wheel_Of_Fortune", References.Wheel_Of_Fortune));
            cards.Add(new Card("Justice", References.Justice));
            cards.Add(new Card("The_Hanged_Man", References.The_Hanged_Man));
            cards.Add(new Card("Death", References.Death));
            cards.Add(new Card("Temperance", References.Temperance));
            cards.Add(new Card("The_Devil", References.The_Devil));
            cards.Add(new Card("The_Tower", References.The_Tower));
            cards.Add(new Card("The_Star", References.The_Star));
            cards.Add(new Card("The_Moon", References.The_Moon));
            cards.Add(new Card("The_Sun", References.The_Sun));
            cards.Add(new Card("Judgement", References.Judgement));
            cards.Add(new Card("The_World", References.The_World));

            return cards;
        }
    }
}
