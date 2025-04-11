using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public bool isObstacle = false;

    public Tile parentTile; 

    private Renderer tileRenderer;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        ResetColor();
    }

    public void Highlight(Color color)
    {
        if (tileRenderer == null)
            tileRenderer = GetComponent<Renderer>();

        tileRenderer.material.color = color;
    }

    public void ResetColor()
    {
        if (tileRenderer == null)
            tileRenderer = GetComponent<Renderer>();

        tileRenderer.material.color = isObstacle ? Color.red : Color.green;
    }
}
