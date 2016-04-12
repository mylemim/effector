using UnityEngine;
using System.Collections;

public class InitializeStaticEnvironment : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    public int maxGameObjectsToInstantiate = 10;

    public string staticLayerName = "World";

    public float minX = 0;
    public float maxX = 10;

    public float minY = 0;
    public float maxY = 10;

    public float maxDistanceRadius = 3;

    //Name of the group object the spawned objects will be stored in
    public GameObject targetGroup;

    // Use this for initialization
    void Start()
    {
        int targetNumberOfObjects = Random.Range(2, maxGameObjectsToInstantiate);
        for (int i = 0; i < targetNumberOfObjects; i++)
        {
            Vector2 newPosition;
            bool isNotIntersectingOtherStaticObjects;
            do
            {
                newPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                isNotIntersectingOtherStaticObjects = Physics2D.OverlapCircle(newPosition, maxDistanceRadius, 1 << LayerMask.NameToLayer(staticLayerName)) != null;
            } while (isNotIntersectingOtherStaticObjects);

            GameObject spawnedGameObject = (GameObject)Instantiate(gameObjectToInstantiate, newPosition, Quaternion.identity);
            if (targetGroup)
                spawnedGameObject.transform.parent = targetGroup.transform;
        }
    }
}
