namespace pizza_jam_raylib.Core
{
    public class RenderTransform
    {
        public double pos_x = 0.0;
        public double pos_y = 0.0;
        public double scale = 1.0;

        public RenderTransform(double x, double y, double s) {
	        pos_x = x;
	        pos_y = y;
	        scale = s;
        }

        public Coord Apply(Coord c)
        {
            return new Coord(ApplyX(c.x), ApplyY(c.y));
        }

        public double ApplyX(double x)
        {
            return (x + pos_x) * scale;
        }

        public double ApplyY(double y)
        {
            return (y + pos_y) * -scale;
        }

        public double ApplyScale(double s)
        {
            return s * scale;
        }

        public double InverseX(double x)
        {
            return (x / scale) - pos_x;
        }

        public double InverseY(double y)
        {
            return (y / -scale) - pos_y;
        }

        public double InverseScale(double s)
        {
            return s / scale;
        }

    }
}
