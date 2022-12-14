namespace Snake_Game.Game.Casting
{
    /// <summary>
    /// Simple implementation of 2d vectors.
    /// </summary>
    public class Vect
    {
        public float x { get; set; }
        public float y { get; set; }
        public Vect(float x,float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vect(double r)
        {
            x = (float) Math.Cos(r);
            y = (float)Math.Sin(r);
        }
        public static Vect operator +(Vect a,Vect b)
        {
            return new Vect(a.x + b.x, a.y + b.y);
        }
        public static Vect operator +(Vect a,Point b)
        {
            return new Vect(a.x + b.x, a.y + b.y);
        }
        public static Vect operator *(Vect a,float b)
        {
            return new Vect(a.x * b, a.y * b); //For some reason this doesnt work
        }
        /// <summary>
        /// Returns the distance between two Vect objects
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public float Dist(Vect bv)
        {
            double a2 = Math.Pow((x - bv.x),2);
            double b2 = Math.Pow((y - bv.y),2);
            return (float) Math.Sqrt(a2+b2);
        }
        public Vect Neg()
        {
            return this * -1;
        }
        public float Mag()
        {
            return Math.Abs(x) + Math.Abs(y);
        }
        /// <summary>
        /// Returns a clamped version of this Vect, where the absolute value of each component is capped to 
        /// the corresponding component of the limit Vect.
        /// </summary>
        /// <returns></returns>
        public Vect Clamp(Vect limit)
        {
            float x = Math.Clamp(this.x, -limit.x, limit.x);
            float y = Math.Clamp(this.y, -limit.y, limit.y);
            return new Vect(x, y);
        }
        public Vect Clamp(float limit)
        {
            float x = Math.Clamp(this.x, -limit, limit);
            float y = Math.Clamp(this.y, -limit, limit);
            return new Vect(x, y);
        }
        public Point toPoint()
        {
            return new Point(((int)x), ((int)y));
        }
    }
}