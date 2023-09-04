namespace Game.Source.WayFinder.Data
{
    public interface IPoint
    {
        int GCost { get; }
        int FCost { get; }
        int HCost { get; }
        int X { get; }
        int Y { get; }
        IPoint Perent { get; set; }
        bool IsBlocked { get; }
        void SetCoordinate(int x , int y);
        void SetPerent(IPoint perent);
        void SetCosts(int gCost , int hCost);
    }
}