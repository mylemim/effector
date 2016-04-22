using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    GameObject winNotification;
   	GameObject loseNotification;

    // Use this for initialization
    void Start () {
        winNotification = GameObject.Find("PlayerWon");
        loseNotification = GameObject.Find("PlayerLost");

        winNotification.SetActive(false);
        loseNotification.SetActive(false);
    }
		
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerWon()
    {
		if(!loseNotification.activeSelf)
        {
            winNotification.SetActive(true);
        }
    }

    public void PlayerLost()
    {
		if (!winNotification.activeSelf)
        {
            loseNotification.SetActive(true);
        }
    }
}
