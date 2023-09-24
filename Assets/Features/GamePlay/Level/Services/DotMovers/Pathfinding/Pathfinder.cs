using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Pathfinding
{
    public class Pathfinder
    {
        public Path Search(ICell startNode, ICell endNode)
        {
            var result = GetEndNode(startNode, endNode);

            if (result.IsValid == false)
            {
                result = GetEndNode(startNode, result.NearestAvailable);
                return CalculatePath(result.EndNode, false);
            }

            return CalculatePath(result.EndNode, result.IsValid);
        }

        private EndNodeResult GetEndNode(ICell startNode, ICell endNode)
        {
            var openList = new List<ICell> { startNode };
            var closedList = new List<ICell>();
            var nearestAvailableNode = endNode;
            var minimalDistanceToAvailable = float.MaxValue;

            var currentNode = startNode;

            while (openList.Count > 0)
            {
                currentNode = GetClosestNode(openList);

                if (currentNode == endNode)
                    return new EndNodeResult(endNode,  nearestAvailableNode, true);

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
                            return new EndNodeResult(currentNode,  nearestAvailableNode, false);

                        continue;
                    }

                    neighbourNode.SetPreviousNode(currentNode);

                    var distance = CalculateDistanceCost(neighbourNode, endNode);

                    if (distance < minimalDistanceToAvailable)
                    {
                        nearestAvailableNode = currentNode;
                        minimalDistanceToAvailable = distance;
                    }
                    
                    neighbourNode.SetDistanceCost(distance);

                    if (openList.Contains(neighbourNode) == false)
                        openList.Add(neighbourNode);
                }
            }

            return new EndNodeResult(currentNode, nearestAvailableNode, false);
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

    public class EndNodeResult
    {
        public EndNodeResult(ICell endNode, ICell nearestAvailable, bool isValid)
        {
            EndNode = endNode;
            NearestAvailable = nearestAvailable;
            IsValid = isValid;
        }
        
        public readonly ICell EndNode;
        public readonly ICell NearestAvailable;
        public readonly bool IsValid;
    }
}