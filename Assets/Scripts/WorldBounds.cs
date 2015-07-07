using UnityEngine;
using System.Collections;

public class WorldBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Set collisions so the enemies can enter and exit the arena at will
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("World Bounds"));
	}
}
