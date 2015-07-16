using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public int points;

	Text text;

	// Use this for initialization
	void Start(){
		points = 0;

		text = gameObject.GetComponent<Text>();
	}

	public void AddPoints(int pointsToAdd){
		points += pointsToAdd;
		text.text = points.ToString ("D7");
	}
}
