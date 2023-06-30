
namespace Game
{
    public class SpawningCoordinates 
    {
        public SpawningCoordinates(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}