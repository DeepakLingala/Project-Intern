using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour, AI
{
    public float moveSpeed = 2f;
    private bool isMoving = false;

    

    public void TakeTurn()
    {
        if (isMoving) return;

        Tile playerTile = PlayerController.Instance.currentTile;
        Tile enemyTile = GridManager.Instance.GetTileFromPosition(transform.position);

        List<Tile> path = Pathfinding.Instance.FindPath(enemyTile, playerTile);

        if (path != null && path.Count > 1)
        {
            Tile targetTile = path[path.Count - 2];
            StartCoroutine(MoveToTile(targetTile));
        }
    }

    IEnumerator MoveToTile(Tile targetTile)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = targetTile.transform.position;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
    }
}
