using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Source.Enemy
{
    public class EnemyMovement
    {
        private MapMeneger _mapManager;
        private Block[,] _land;
        private List<Point> _closedPoint;
        private Point[,] _pointsMap;
        private int _mapWidth;
        private int _mapHeight;
        

        public EnemyMovement(MapMeneger MapManager)
        {
            _mapManager = MapManager;
            _land = _mapManager.CurrentMap.Land;
            _mapWidth = _land.GetLength(0);
            _mapHeight = _land.GetLength(1);
            BlockToPointConversion();
        }

        public void WalkToPosition(Vector2Int StartPoint, Vector2Int TargetPoint)
        {
            OutOfBoundsTest(StartPoint, TargetPoint);
        }

        private void OutOfBoundsTest(Vector2Int firstPoint, Vector2Int secondPoint)
        {
            

            if (firstPoint.x < 0 || firstPoint.y < 0 || secondPoint.x < 0 || secondPoint.y < 0 ||
                firstPoint.x >= _mapWidth || firstPoint.y >= _mapHeight || secondPoint.x >= _mapWidth || secondPoint.y >= _mapHeight)
            {
                throw new IndexOutOfRangeException("The point is outside the map");
            }
        }

        private void BlockToPointConversion()
        {
            _pointsMap = new Point[_land.GetLength(0), _land.GetLength(1)];
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    _pointsMap[x, y] = new Point(x, y);
                    if (_land[x, y].BlockState == BlockStates.NotAvailable)
                    {
                        _pointsMap[x,y].SetBlocked();
                    }
                }
            }
        }

        private List<Point> FindePath(Vector2Int startPoint, Vector2Int endPoint)
        {
            _closedPoint = new List<Point>();
            Point EndPoint = GetPointByCoordinates(endPoint);
            
            Point currentPoint = GetPointByCoordinates(startPoint);
            bool isFinde = false;

            while (isFinde)
            {
                if (currentPoint == EndPoint)
                {
                    isFinde = true;
                }
                
                
            }
            return _closedPoint;
        }

        private List<Point> GetNeighbors(Vector2Int Point)
        {
            List<Point> neighbors = new List<Point>();

            int[] offsetX = { -1, 0, 1, 0 };
            int[] offsetY = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int newX = Point.x + offsetX[i];
                int newY = Point.y + offsetY[i];

                GetPointByCoordinates(new Vector2Int(newX, newY));
            }

            return neighbors;
        }

        private Point GetPointByCoordinates(Vector2Int Point)
        {
            if (Point.x < 0 || Point.y < 0 || Point.x >= _mapWidth || Point.y >= _mapHeight)
            {
                Source.Enemy.Point NewPoint = new Point(false);
                return NewPoint;
            }

           return _pointsMap[Point.x, Point.y];
        }
            
       // private int GetDistance()
   }
}