namespace tarot_card_battler.Core
{
    public class EntityLayer
    {
        public List<Entity> entities = new List<Entity>();

        public void Update()
        {
            foreach (Entity entity in entities)
            {
                entity.Update();
            }

            for(int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity = entities[i];
                if (entity.destroyed)
                {
                    entities.Remove(entity);
                }
            }
        }


        public void Render()
        {
            foreach (Entity entity in entities)
            {
                entity.Render();
            }
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }
    }
}
