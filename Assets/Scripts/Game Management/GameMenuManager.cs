using UnityEngine;
using System.Collections;

public class GameMenuManager : MenuManager {

	const string ESCAPE = "escape";

	public GameObject menu;

	private bool isPaused = false;

	void Start(){
		Time.timeScale = 1;
		menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (ESCAPE)) {
			if (!isPaused)
				this.Pause ();
			else 
				this.Resume ();
		}
	}

	public void Pause(){
		Time.timeScale = 0;
		menu.SetActive (true);
		isPaused = true;
	}

	public void Resume(){
		Time.timeScale = 1;
		menu.SetActive (false);
		isPaused = false;
	}
}
