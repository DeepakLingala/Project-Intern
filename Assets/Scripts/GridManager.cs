using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab;
    public Tile[,] tiles;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tileObj = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                tileObj.name = $"Tile {x},{y}";
                Tile tile = tileObj.GetComponent<Tile>();
                tile.x = x;
                tile.y = y;
                tiles[x, y] = tile;
            }
        }
    }

    public Tile GetTileFromPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.z);
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return tiles[x, y];
        }
        return null;
    }

    public List<Tile> GetNeighbors(Tile tile)
    {
        List<Tile> neighbors = new List<Tile>();

        int[,] directions = new int[,]
        {
            { 0, 1 },
            { 1, 0 },  
            { 0, -1 },
            { -1, 0 } 
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int checkX = tile.x + directions[i, 0];
            int checkY = tile.y + directions[i, 1];

            if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
            {
                Tile neighbor = tiles[checkX, checkY];
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }
}