using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	const string FIRST_LEVEL_NAME = "level";

	public void ExitGame ()
	{
		Application.Quit ();
	}

	public void StartNewGame ()
	{
		SceneManager.LoadScene (FIRST_LEVEL_NAME);
	}
}
