using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private UiManager uiManager;
	private SpawnManager spawnManager;

	//Awake is always called before any Start functions
	void Awake()
	{
		uiManager = GameObject.Find ("UiManager").GetComponent<UiManager> ();
		spawnManager =  GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
	}

	void Start(){
		Debug.Log ("Current level: " + GameManager.instance.Level);
	}

	public void PlayerWon()
	{
		uiManager.PlayerWon();
	}

	public void PlayerLost()
	{
		uiManager.PlayerLost();
	}

	public void CompleteLevel(){
		GameManager.instance.RestartLevel ();
	}
}
