using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{	
	const string MENU_LEVEL_NAME = "menu";
	const string FIRST_LEVEL_NAME = "level";
	const string CREDITS_LEVEL_NAME = "credits";

	public void ExitGame ()
	{
		Application.Quit ();
	}

	public void StartNewGame ()
	{
		SceneManager.LoadScene (FIRST_LEVEL_NAME);
	}

	public void Credits(){
		SceneManager.LoadScene (CREDITS_LEVEL_NAME);
	}

	public void MainMenu(){
		SceneManager.LoadScene (MENU_LEVEL_NAME);
	}
}
