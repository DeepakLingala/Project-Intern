using UnityEngine;
using TMPro;

public class TileHighlighter : MonoBehaviour
{
    public TextMeshProUGUI tileInfoText;
    private Tile lastHoveredTile;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();

            if (tile != null)
            {
                tileInfoText.text = $"Tile Position: ({tile.x}, {tile.y})";

                if (lastHoveredTile != tile)
                {
                    if (lastHoveredTile != null)
                        lastHoveredTile.ResetColor();

                    tile.Highlight(Color.yellow);
                    lastHoveredTile = tile;
                }
            }
        }
        else
        {
            tileInfoText.text = "No tile Detected";

            if (lastHoveredTile != null)
            {
                lastHoveredTile.ResetColor();
                lastHoveredTile = null;
            }
        }
    }
}
