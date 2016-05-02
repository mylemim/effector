using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    UiManager uiManager;

    // Use this for initialization
    void Start () {
        uiManager = GetComponent<UiManager>();
    }
		
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerWon()
    {
        uiManager.PlayerWon();
    }

    public void PlayerLost()
    {
        uiManager.PlayerLost();
    }
}
