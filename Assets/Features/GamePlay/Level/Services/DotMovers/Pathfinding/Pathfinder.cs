using System.Collections.Generic;
using System.Linq;
using GamePlay.Level.Cells.Runtime;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Pathfinding
{
    public class Pathfinder
    {
        public Path Search(ICell startNode, ICell endNode)
        {
            var openList = new List<ICell> { startNode };
            var closedList = new List<ICell>();

            var currentNode = startNode;

            while (openList.Count > 0)
            {
                currentNode = GetClosestNode(openList);

                if (currentNode == endNode)
                    return CalculatePath(endNode, true);

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (var neighbourNode in currentNode.Neighbours)
                {
                    if (closedList.Contains(neighbourNode) == true)
                        continue;

                    if (neighbourNode.Dot != null && neighbourNode.Dot.LifeFlow.IsActive == true)
                    {
                        closedList.Add(neighbourNode);

                        if (neighbourNode == endNode)
                            return CalculatePath(currentNode, false);

                        continue;
                    }

                    neighbourNode.SetPreviousNode(currentNode);

                    var distance = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.SetDistanceCost(distance);

                    if (openList.Contains(neighbourNode) == false)
                        openList.Add(neighbourNode);
                }
            }

            return CalculatePath(currentNode, false);
        }

        private Path CalculatePath(ICell endNode, bool isValid)
        {
            var path = new List<ICell> { endNode };

            var currentNode = endNode;

            while (currentNode.PreviousNode != null)
            {
                path.Add(currentNode.PreviousNode);
                currentNode = currentNode.PreviousNode;
            }

            path.Reverse();

            if (isValid == false)
                return MinimizeInvalidPath(path);
            
            return new Path(path, true);
        }

        private Path MinimizeInvalidPath(IReadOnlyList<ICell> cells)
        {
            var nearestCell = cells.Last();
            var minDistance = float.MaxValue;

            foreach (var cell in cells)
            {
                var distance = CalculateDistanceCost(nearestCell, cell);

                if (distance > minDistance)
                    continue;

                nearestCell = cell;
                minDistance = distance;
            }

            var newCells = new List<ICell>();

            foreach (var cell in cells)
            {
                if (cell == nearestCell)
                {
                    newCells.Add(cell);
                    return new Path(newCells, false);
                }

                newCells.Add(cell);
            }

            return new Path(cells, false);
        }

        private float CalculateDistanceCost(ICell a, ICell b)
        {
            return Vector2Int.Distance(a.Position, b.Position);
        }

        private ICell GetClosestNode(IReadOnlyList<ICell> pathNodeList)
        {
            var lowestFCostNode = pathNodeList[0];

            for (var i = 1; i < pathNodeList.Count; i++)
            {
                if (pathNodeList[i].DistanceToTarget < lowestFCostNode.DistanceToTarget)
                    lowestFCostNode = pathNodeList[i];
            }

            return lowestFCostNode;
        }
    }
}