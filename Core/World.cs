using Raylib_cs;

namespace pizza_jam_raylib.Core
{
    public class World
    {
        public Color background = Color.DarkGray;
        public List<Entity> entities = new List<Entity>();

        public void Update(float delta)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(delta);
            }
        }


        public void Render(Coord a, Coord b, RenderTransform transform)
        {
            Raylib.DrawRectangle((int)a.x, (int)a.y, (int)(b.x - a.x), (int)(b.y - a.y), background);

            foreach (Entity entity in entities)
            {
                entity.Render(transform);
            }
        }
    }
}
