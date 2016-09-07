using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	private UiManager uiManager;
	private SpawnManager spawnManager;
	private InitializeStaticEnvironment environmentManager;

	public int EnemiesPerLevelMultiplier = 2;

	//Awake is always called before any Start functions
	void Awake ()
	{
		uiManager = GameObject.Find ("UiManager").GetComponent<UiManager> ();

		spawnManager = GameObject.Find ("SpawnManager").GetComponent<SpawnManager> ();
		spawnManager.GameObjectsToInstantiate = GameManager.instance.Level * EnemiesPerLevelMultiplier;
	
		environmentManager = GameObject.Find ("EnvironmentManager").GetComponent<InitializeStaticEnvironment> ();
		environmentManager.minGameObjectsToInstantiate = Mathf.RoundToInt (GameManager.instance.Level / 2f); 
		environmentManager.maxGameObjectsToInstantiate = Mathf.RoundToInt (GameManager.instance.Level / 1.2f); 
	}

	void Start ()
	{
		Debug.Log ("Current level: " + GameManager.instance.Level);
	}

	public void PlayerWon ()
	{
		uiManager.PlayerWon ();
	}

	public void PlayerLost ()
	{
		uiManager.PlayerLost ();
	}

	public void CompleteLevel ()
	{
		GameManager.instance.RestartLevel ();
	}
}
