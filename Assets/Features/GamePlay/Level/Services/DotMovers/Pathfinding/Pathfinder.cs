using System.Collections.Generic;
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

                    if (neighbourNode.Dot != null)
                    {
                        closedList.Add(neighbourNode);

                        if (neighbourNode == endNode)
                            return CalculatePath(currentNode, false);

                        continue;
                    }

                    neighbourNode.PreviousNode = currentNode;

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
            path.RemoveAt(0);

            return new Path(path, isValid);
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