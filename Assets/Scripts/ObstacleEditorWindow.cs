using UnityEditor;
using UnityEngine;

public class ObstacleEditorWindow : EditorWindow
{
    public ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Grid Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditorWindow>("Obstacle Grid Editor");
    }

    private void OnGUI()
    {
        obstacleData = (ObstacleData)EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false);

        if (obstacleData == null)
        {
            EditorGUILayout.HelpBox("Assign an ObstacleData asset.", MessageType.Warning);
            return;
        }

        EditorGUILayout.LabelField("Toggle Obstacles (10x10):");

        for (int y = 9; y >= 0; y--) 
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < 10; x++)
            {
                int index = x + y * 10;
                obstacleData.obstacleArray[index] = EditorGUILayout.Toggle(obstacleData.obstacleArray[index], GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(obstacleData);
            AssetDatabase.SaveAssets();
        }
    }
}
