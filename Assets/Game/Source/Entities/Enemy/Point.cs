using System;

namespace Game.Source.Enemy
{
    public class Point
    {
        public int GCost;
        public int HCost;
        public int X { get; private set; }
        public int Y { get; private set; }
        
        public int FCost { get { return GCost + HCost; } }
        public bool IsBlocked { get; private set;}
        public Point Perent { get; private set; }
        
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point(bool PointState)
        {
            IsBlocked = PointState;
        }
        
        public void SetPerent(Point Perent)
        {
            if (Perent == null)
            {
                throw new NullReferenceException("You try set null perent");
            }
            this.Perent = Perent;
        }

        public void SetBlocked()
        {
            IsBlocked = true;
        }
    }
}