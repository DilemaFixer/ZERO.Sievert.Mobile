using System;
using System.Collections;
using System.Collections.Generic;
using Game.Source.WayFinder.Data;
using UnityEngine;

namespace Game.Source.WayFinder
{
    public class WayFinder
    {
        private IPoint[,] _pointMap;
        private int  Height{get{ return _pointMap.GetLength(0); }}
        private int Width { get { return _pointMap.GetLength(1); }}

        public List<IPoint> FindWay(Vector2Int startPointCoordinates, Vector2Int targetPointCoordinates)
        {
            List<IPoint> openSet = new List<IPoint>();
            List<IPoint> closeSet = new List<IPoint>();

            IPoint startPoint = _pointMap[startPointCoordinates.x, startPointCoordinates.y];
            IPoint targetPoint = _pointMap[targetPointCoordinates.x, targetPointCoordinates.y];
            
            openSet.Add(startPoint);

            while (openSet.Count > 0)
            {
                IPoint currentPoint = openSet[0];
                for (int i = 0; i < openSet.Count; i++)
                {
                    if(openSet[i].FCost > currentPoint.FCost || 
                       (openSet[i].FCost == currentPoint.FCost && openSet[i].HCost < currentPoint.HCost))
                    {
                        currentPoint = openSet[i];
                    }
                }

                if (currentPoint.X == targetPoint.X || startPoint.Y == targetPoint.Y)
                {
                    return GeneratePath(currentPoint, startPoint);
                }

                foreach (var point in GetNeighbors(currentPoint))
                {
                    if(point.IsBlocked == true && closeSet.Contains(point))
                        continue;
                    
                    float GCostFloat = Vector2Int.Distance(new Vector2Int(currentPoint.X , currentPoint.Y) , new Vector2Int(point.X , point.Y));
                    int GCostInt = Convert.ToInt32(GCostFloat) + currentPoint.GCost;

                    float HCostFloat = Vector2Int.Distance(new Vector2Int(currentPoint.X , currentPoint.Y) , new Vector2Int(targetPoint.X , targetPoint.Y));
                    int HCostInt = Convert.ToInt32(HCostFloat);

                    
                    if (!closeSet.Contains(point) || point.HCost > currentPoint.HCost)
                    {
                        point.SetPerent(currentPoint);
                        point.SetCosts(GCostInt , HCostInt);
                        openSet.Add(point);
                    }
                }
            }

            return null;
        }

        private List<IPoint> GetNeighbors(IPoint point)
        {
            List<Vector2Int> neighborsCoordinate = new List<Vector2Int>
            {
                new Vector2Int(point.X + 1, point.Y),         
                new Vector2Int(point.X - 1, point.Y),        
                new Vector2Int(point.X, point.Y + 1),        
                new Vector2Int(point.X, point.Y - 1),         
                new Vector2Int(point.X + 1, point.Y + 1),     
                new Vector2Int(point.X - 1, point.Y + 1),     
                new Vector2Int(point.X + 1, point.Y - 1),     
                new Vector2Int(point.X - 1, point.Y - 1)     
            };
            List<IPoint> neighbors = new List<IPoint>();
            
            for (int i = 0; i < neighborsCoordinate.Count; i++)
            {
                neighbors.Add(_pointMap[neighborsCoordinate[i].x , neighborsCoordinate[i].y]);
            }

            return neighbors;
        }

        private List<IPoint> GeneratePath(IPoint point , IPoint targetPoint)
        {
            List<IPoint> path = new List<IPoint>();
            IPoint currentPoint = point;
            path.Add(currentPoint);
           
            while (currentPoint.X != targetPoint.X || currentPoint.Y != targetPoint.Y)
            {
                currentPoint = currentPoint.Perent;
                path.Add(currentPoint);
            }

            path.Reverse();
            return path;
        } 
    }
}