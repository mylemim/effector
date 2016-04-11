using UnityEngine;
using System.Collections;

public class InitializeStaticEnvironment : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;
    public int maxGameObjectsToInstantiate = 10;

    public float minX = 0;
    public float maxX = 10;

    public float minY = 0;
    public float maxY = 10;

    //Name of the group object the spawned objects will be stored in
    public GameObject targetGroup;

    // Use this for initialization
    void Start()
    {
        int targetNumberOfObjects = Random.Range(2, maxGameObjectsToInstantiate);

        for (int i = 0; i < targetNumberOfObjects; i++)
        {
            Vector2 newPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject spawnedGameObject = (GameObject)Instantiate(gameObjectToInstantiate, newPosition, Quaternion.identity);
            if (targetGroup)
                spawnedGameObject.transform.parent = targetGroup.transform;
        }
    }
}
