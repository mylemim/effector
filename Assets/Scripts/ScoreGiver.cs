using UnityEngine;
using System.Collections;

public class ScoreGiver : MonoBehaviour {

	public int PointsAwarded = 10;
	public string ScoreCounterName = "Score Counter";
	
	void OnDestroy(){
		GameObject scoreCounter = GameObject.Find (ScoreCounterName);	
		if(scoreCounter!=null)
			scoreCounter.GetComponent<ScoreCounter>().AddPoints (PointsAwarded);
	}
}
