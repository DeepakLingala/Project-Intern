using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public static Pathfinding Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Tile> FindPath(Tile startTile, Tile targetTile)
    {
        List<Tile> openSet = new List<Tile>();
        HashSet<Tile> closedSet = new HashSet<Tile>();

        openSet.Add(startTile);

        Dictionary<Tile, float> gCost = new Dictionary<Tile, float>();
        Dictionary<Tile, float> fCost = new Dictionary<Tile, float>();

        gCost[startTile] = 0;
        fCost[startTile] = GetHeuristic(startTile, targetTile);

        while (openSet.Count > 0)
        {
            Tile current = GetLowestFCost(openSet, fCost);

            if (current == targetTile)
                return RetracePath(startTile, targetTile);

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (Tile neighbor in GridManager.Instance.GetNeighbors(current))
            {
                if (neighbor.isObstacle || closedSet.Contains(neighbor))
                    continue;

                float tentativeGCost = gCost[current] + 1;

                if (!gCost.ContainsKey(neighbor) || tentativeGCost < gCost[neighbor])
                {
                    gCost[neighbor] = tentativeGCost;
                    fCost[neighbor] = gCost[neighbor] + GetHeuristic(neighbor, targetTile);
                    neighbor.parentTile = current;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null;
    }

    private float GetHeuristic(Tile a, Tile b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y); 
    }

    private Tile GetLowestFCost(List<Tile> openSet, Dictionary<Tile, float> fCost)
    {
        Tile lowest = openSet[0];
        float minF = fCost[lowest];

        foreach (Tile tile in openSet)
        {
            if (fCost.ContainsKey(tile) && fCost[tile] < minF)
            {
                lowest = tile;
                minF = fCost[tile];
            }
        }
        return lowest;
    }

    private List<Tile> RetracePath(Tile start, Tile end)
    {
        List<Tile> path = new List<Tile>();
        Tile current = end;

        while (current != start)
        {
            path.Add(current);
            current = current.parentTile;
        }
        path.Reverse();
        return path;
    }
}
