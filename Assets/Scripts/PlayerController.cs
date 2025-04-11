using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isMoving = false;
    public static PlayerController Instance;

    public Tile currentTile;

    void Awake()
    {
        Instance = this;
    }

    void Start()
{
    if (GridManager.Instance != null)
    {
        currentTile = GridManager.Instance.GetTileFromPosition(transform.position);
    }
    else
    {
        Debug.LogError("GridManager.Instance is still null!");
    }
}

    void Update()
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null && !tile.isObstacle)
                {
                    currentTile = GetCurrentTile();
                    List<Tile> path = Pathfinding.Instance.FindPath(currentTile, tile);
                    if (path != null)
                    {
                        StartCoroutine(MoveAlongPath(path));
                    }
                }
            }
        }
    }

    Tile GetCurrentTile()
    {
        Vector3 pos = transform.position;
        return GridManager.Instance.tiles[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)];
    }

    IEnumerator MoveAlongPath(List<Tile> path)
    {
        isMoving = true;
        foreach (Tile tile in path)
        {
            Vector3 targetPos = new Vector3(tile.x, 0.5f, tile.y);
            while (Vector3.Distance(transform.position, targetPos) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        isMoving = false;
    }
}
