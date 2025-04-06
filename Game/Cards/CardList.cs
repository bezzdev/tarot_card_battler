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
        public static List<Card> cards;

        public static List<Card> GetAllCards()
        {
            List<Card> cards = new List<Card>();

            cards.Add(new Card("The_Fool", 00, References.The_Fool)
            {
                pastEffect = new ShuffleField(),
                presentEffect = new ShuffleDiscard(),
                futureEffect = new ShuffleDiscard()
            });
            cards.Add(new Card("The_Magician", 01, References.The_Magician){
                pastEffect = new CopyOpposite(0),
                presentEffect = new CopyOpposite(1),
                futureEffect = new CopyOpposite(2),
            });
            cards.Add(new Card("The_High_Priestess", 02, References.The_High_Priestess){
                pastEffect = new DamageEffect(1),
                presentEffect = new DamageEffect(2),
                futureEffect = new DamageEffect(3),
            });
            cards.Add(new Card("The_Empress", 03, References.The_Empress));
            cards.Add(new Card("The_Emperor", 04, References.The_Emperor));
            cards.Add(new Card("The_Hierophant", 05, References.The_Hierophant));
            cards.Add(new Card("The_Lovers", 06, References.The_Lovers)
            {
                pastEffect = new Heal(1),
                presentEffect = new Heal(2),
                futureEffect = new Heal(3),
            });
            cards.Add(new Card("The_Chariot", 07, References.The_Chariot){
                pastEffect = new ShuffleField(),
                presentEffect = new ShuffleField(),
                futureEffect = new ShuffleField(),
            });
            cards.Add(new Card("Strength", 08, References.Strength));
            cards.Add(new Card("The_Hermit", 09, References.The_Hermit));
            cards.Add(new Card("Wheel_Of_Fortune", 10, References.Wheel_Of_Fortune){
                pastEffect = new RandomDiscardEffect(),
                presentEffect = new RandomDamage(),
                futureEffect = new RandomHeal(),
            });
            cards.Add(new Card("Justice", 11, References.Justice));
            cards.Add(new Card("The_Hanged_Man", 12, References.The_Hanged_Man));
            cards.Add(new Card("Death", 13, References.Death));
            cards.Add(new Card("Temperance", 14, References.Temperance));
            cards.Add(new Card("The_Devil", 15, References.The_Devil));
            cards.Add(new Card("The_Tower", 16, References.The_Tower));
            cards.Add(new Card("The_Star", 17, References.The_Star));
            cards.Add(new Card("The_Moon", 18, References.The_Moon));
            cards.Add(new Card("The_Sun", 19, References.The_Sun));
            cards.Add(new Card("Judgement", 20, References.Judgement));
            cards.Add(new Card("The_World", 21, References.The_World));

            return cards;
        }

        public static Card GetCard(int n)
        {
            return cards[n].Clone();
        }

        public static void Shuffle(List<Card> cards)
        {
            List<Card> temp = new List<Card>();
            foreach(Card card in cards)
            {
                temp.Add(card);
            }
            cards.Clear();

            while (temp.Count > 0)
            {
                int choice = Random.Shared.Next(0, temp.Count);
                Card card = temp[choice];
                temp.RemoveAt(choice);
                cards.Add(card);
            }
        }
    }
}
