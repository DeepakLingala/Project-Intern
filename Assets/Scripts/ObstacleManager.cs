using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab; 

    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                int index = x + y * 10;
                if (obstacleData.obstacleArray[index])
                {
                    Vector3 pos = new Vector3(x, 0.5f, y); 
                    Instantiate(obstaclePrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
