using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Game.Effects;
using tarot_card_battler.Game.PlayArea;

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
                presentEffect = new SwapAboveWithRandomFromHand(),
                futureEffect = new Nullify()
            });
            cards.Add(new Card("The_Magician", 01, References.The_Magician)
            {
                pastEffect = new CopyOpposite(),
                presentEffect = new CopyOpposite(),
                futureEffect = new CopyOpposite(),
            });
            cards.Add(new Card("The_High_Priestess", 02, References.The_High_Priestess)
            {
                pastEffect = new ShuffleDiscard(),
                presentEffect = new Heal(2),
                futureEffect = new Damage(2)
            });
            cards.Add(new Card("The_Empress", 03, References.The_Empress)
            {
                pastEffect = new Shield(5),
                presentEffect = new Heal(2),
                futureEffect = new Draw()
            });
            cards.Add(new Card("The_Emperor", 04, References.The_Emperor)
            {
                pastEffect = new Shield(5),
                presentEffect = new Damage(3),
                futureEffect = new AddGold(2)
            });
            cards.Add(new Card("The_Hierophant", 05, References.The_Hierophant)
            {
                pastEffect = new ShieldDamage(),
                presentEffect = new Heal(3),
                futureEffect = new AddGold(2)
            });
            cards.Add(new Card("The_Lovers", 06, References.The_Lovers)
            {
                pastEffect = new BuffAdjacentSlot(1, 2),
                presentEffect = new BuffAdjacentSlot(2, 2),
                futureEffect = new Heal(3),
            });
            cards.Add(new Card("The_Chariot", 07, References.The_Chariot)
            {
                pastEffect = new DebuffOppositeSlot(1, -2),
                presentEffect = new Heal(3),
                futureEffect = new DebuffOppositeSlot(2, -2)
            });
            cards.Add(new Card("Strength", 08, References.Strength)
            {
                pastEffect = new Weakness(),
                presentEffect = new Damage(3),
                futureEffect = new Strength()
            });

            cards.Add(new Card("The_Hermit", 09, References.The_Hermit)
            {
                pastEffect = new StealOpponentGold(1),
                presentEffect = new Damage(3),
                futureEffect = new StealOpponentGold(1),
            });
            cards.Add(new Card("Wheel_Of_Fortune", 10, References.Wheel_Of_Fortune)
            {
                pastEffect = new RandomDiscardEffect(),
                presentEffect = new RandomDamage(1, 5),
                futureEffect = new RandomHeal(1, 5),
            });
            cards.Add(new Card("Justice", 11, References.Justice)
            {
                pastEffect = new AddGold(1),
                presentEffect = new Damage(3),
                futureEffect = new AddGold(1)
            });
            cards.Add(new Card("The_Hanged_Man", 12, References.The_Hanged_Man)
            {
                pastEffect = new Nullify(),
                presentEffect = new Nullify(),
                futureEffect = new Nullify()
            });
            cards.Add(new Card("Death", 13, References.Death)
            {
                pastEffect = new StrengthDeathCountdown(),
                presentEffect = new Damage(6),
                futureEffect = new DeathCountdown()
            });
            cards.Add(new Card("Temperance", 14, References.Temperance)
            {
                pastEffect = new DamageGoldAmount(),
                presentEffect = new Damage(3),
                futureEffect = new AddGold(1),
            });
            cards.Add(new Card("The_Devil", 15, References.The_Devil)
            {
                pastEffect = new Damage(3),
                presentEffect = new Damage(3),
                futureEffect = new Weakness()
            });
            cards.Add(new Card("The_Tower", 16, References.The_Tower)
            {
                pastEffect = new Nullify(),
                presentEffect = new Damage(3),
                futureEffect = new Nullify()
            });
            cards.Add(new Card("The_Star", 17, References.The_Star)
            {
                pastEffect = new StealOpponentGold(2),
                presentEffect = new Damage(3),
                futureEffect = new CopyOpposite()
            });
            cards.Add(new Card("The_Moon", 18, References.The_Moon)
            {
                pastEffect = new DamageGoldAmount(),
                presentEffect = new Damage(3),
                futureEffect = new DebuffOppositeSlot(2, 2),
            });
            cards.Add(new Card("The_Sun", 19, References.The_Sun)
            {
                pastEffect = new HealGoldAmount(),
                presentEffect = new Heal(3),
                futureEffect = new StrengthHeal()
            });
            cards.Add(new Card("Judgement", 20, References.Judgement)
            {
                pastEffect = new ShuffleField(),
                presentEffect = new Damage(3),
                futureEffect = new DamageGoldAmount()
            });
            cards.Add(new Card("The_World", 21, References.The_World)
            {
                pastEffect = new Damage(1),
                presentEffect = new Heal(3),
                futureEffect = new AddGold(2)
            });

            return cards;
        }

        public static Card GetCard(int n)
        {
            return cards[n].Clone();
        }

        public static void Shuffle(List<Card> cards)
        {
            List<Card> temp = new List<Card>();
            foreach (Card card in cards)
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
