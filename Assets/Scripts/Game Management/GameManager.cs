using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	//Static instance of GameManager which allows it to be accessed by any other script.

	public int Level {
		get {
			return level;
		}
	}

	private int level = 1;

	//Awake is always called before any Start functions
	void Awake ()
	{
		Debug.Log ("Game manager awake");

		//Singleton pattern
		if (instance == null) {
			Debug.Log ("Game manager got new instance");
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void OnLevelWasLoaded (int level)
	{
		this.level++;
	}

	public void RestartLevel ()
	{
		Debug.Log ("Restarting level");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
