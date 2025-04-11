using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacleData", menuName = "Grid/Obstacle Data")]
public class ObstacleData : ScriptableObject
{
    public bool[] obstacleArray = new bool[100]; 
}
