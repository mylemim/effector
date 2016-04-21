using UnityEngine;
using System.Collections;

public class SetupCamera : MonoBehaviour {

    float mapX = 20f;
    float mapY = 10f;

    private float minX;
     private float maxX;
     private float minY;
     private float maxY;

	// Use this for initialization
	void Start () {
        float verticalExtent = Camera.main.orthographicSize;
        float horizontalExtent = verticalExtent * Screen.width / Screen.height;

        minX = horizontalExtent - mapX / 2;
        maxX = mapX / 2 - horizontalExtent;
        minY = verticalExtent - mapY / 2;
        maxY = mapY / 2 - verticalExtent;
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //Limit the camera to the size of the ortographic projection
            Vector2 playerPosition = player.transform.position;
            Vector3 newPosition = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;
        }
    }
}
