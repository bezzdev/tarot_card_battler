namespace tarot_card_battler.Core
{
    public class Entity
    {
        public int layer = 0;
        public Coord position = new Coord(0, 0);

        public virtual bool Intersect(double x, double y)
        {
            return false;
        }

        public virtual bool Interact(double x, double y)
        {
            return Intersect(x, y);
        }

        public virtual float Distance(double x, double y)
        {
            return float.MaxValue;
        }

        public virtual bool Draggable()
        {
            return false;
        }
        public virtual void OnStartDragging(double x, double y)
        {
        }
        public virtual void OnDrag(double x, double y, double dx, double dy)
        {
        }
        public virtual void OnStopDragging(double x, double y)
        {
        }

        public virtual void Update(float delta)
        {

        }

        public virtual void Render(RenderTransform transformer)
        {
            //double x1 = transformer.ApplyX(position.x);
            //double y1 = transformer.ApplyY(position.y);
            //double x2 = transformer.ApplyX(position.x + width);
            //double y2 = transformer.ApplyY(position.y + height);

            //Rectangle rec = new Rectangle((float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            //Raylib.DrawRectangleRounded(rec, 0.2f, 2, new Color(48, 48, 48, 255));
        }
    }
}
