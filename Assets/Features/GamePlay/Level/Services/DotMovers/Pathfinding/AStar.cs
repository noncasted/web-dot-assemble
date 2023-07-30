using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Services.DotMovers.Pathfinding.PriorityQueue;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Pathfinding
{
    /// <summary>
    /// Implementation of Amit Patel's A* Pathfinding algorithm studies
    /// https://www.redblobgames.com/pathfinding/a-star/introduction.html
    /// </summary>
    public static class AStar
    {
        /// <summary>
        /// Returns the best path as a List of Nodes
        /// </summary>
        public static List<ICell> Search(ICell start, ICell goal)
        {
            var came_from = new Dictionary<ICell, ICell>();
            var cost_so_far = new Dictionary<ICell, float>();

            var path = new List<ICell>();

            var frontier = new SimplePriorityQueue<ICell>();
            frontier.Enqueue(start, 0);

            came_from.Add(start, start);
            cost_so_far.Add(start, 0);

            ICell current = null;
            while (frontier.Count > 0)
            {
                current = frontier.Dequeue();

                if (current == goal)
                    break;

                foreach (var next in current.Neighbours)
                {
                    if (next.Dot != null)
                        continue;

                    var new_cost = cost_so_far[current] + 1;
                    if (!cost_so_far.ContainsKey(next) || new_cost < cost_so_far[next])
                    {
                        cost_so_far[next] = new_cost;
                        came_from[next] = current;
                        var priority = new_cost + Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        next.Priority = new_cost;
                    }
                }
            }

            while (current != start)
            {
                path.Add(current);
                current = came_from[current];
            }

            path.Reverse();

            return path;
        }

        private static float Heuristic(ICell a, ICell b)
        {
            return Mathf.Abs(a.Position.x - b.Position.x) + Mathf.Abs(a.Position.y - b.Position.y);
        }
    }
}