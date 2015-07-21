using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

	public int PointsAwarded = 10;
	public string ScoreCounterName = "Score Counter";
	
	void OnDestroy(){
		GameObject scoreCounter = GameObject.Find (ScoreCounterName);	
		if(scoreCounter!=null)
			scoreCounter.GetComponent<Counter>().Value += PointsAwarded;
	}
}
