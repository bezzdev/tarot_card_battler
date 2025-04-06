using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Util
{
    public static class Intersections
    {
        public static Entity GetClosestInteractable(List<Entity> entities, double x, double y)
        {
            List<Entity> hits = new List<Entity>();
            foreach (Entity ent in entities)
            {
                if (ent.Interact(x, y))
                {
                    hits.Add(ent);
                }
            }

            hits.Sort((a, b) => a.Distance(x, y) - b.Distance(x, y) < 0f ? -1 : 1);

            if (hits.Count > 0)
            {
                return hits[0];
            }

            return null;
        }

        public static Card GetHoveredCard(List<Card> cards, double x, double y){
            foreach (Card card in cards)
            {
                if (card.IsInBounds(x, y))
                {
                    return card;
                }
            }
            return null;
        }


        public static Entity GetClosestInteractableOnTop(List<Entity> entities, double x, double y)
        {
            List<Entity> hits = new List<Entity>();
            int maxLayer = 0;

            foreach (Entity ent in entities)
            {
                if (ent.Interact(x, y))
                {
                    hits.Add(ent);
                    if (ent.layer > maxLayer)
                    {
                        maxLayer = ent.layer;
                    }
                }
            }

            hits = hits.Where(h => h.layer == maxLayer).ToList();
            hits.Sort((a, b) => a.Distance(x, y) - b.Distance(x, y) < 0f ? -1 : 1);

            if (hits.Count > 0)
            {
                return hits[0];
            }

            return null;
        }
    }
}
