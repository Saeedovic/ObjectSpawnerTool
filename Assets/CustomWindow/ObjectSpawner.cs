using UnityEditor;
using UnityEngine;

public class ObjectSpawner : EditorWindow
{
    string objectName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;




    [MenuItem("Tools/Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ObjectSpawner));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn Object", EditorStyles.boldLabel);


        objectName = EditorGUILayout.TextField("Base Name", objectName);
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f, 3f);
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }
    }


    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("no object is assigned");
            return;
        }

        if (objectName == string.Empty)
        {
            Debug.LogError("Enter a name for the object ");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnpos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnpos, Quaternion.identity);
        newObject.name = objectName + objectID;
        newObject.transform.localScale = Vector3.one * objectScale;

        objectID++;





    }


}
