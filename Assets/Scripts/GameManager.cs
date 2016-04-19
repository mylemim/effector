using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static GameObject winNotification;
    static GameObject loseNotification;

    static bool isGameFinished = false;

    // Use this for initialization
    void Start () {
        winNotification = GameObject.Find("PlayerWon");
        loseNotification = GameObject.Find("PlayerLost");

        winNotification.SetActive(false);
        loseNotification.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
	
	}

    static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void PlayerWon()
    {
        if(!isGameFinished)
        {
            isGameFinished = true;
            winNotification.SetActive(true);
            winNotification.GetComponentInChildren<Button>().onClick.AddListener(() => { RestartLevel(); });
        }
    }

    public static void PlayerLost()
    {
        if (!isGameFinished)
        {
            isGameFinished = true;
            loseNotification.SetActive(true);
            loseNotification.GetComponentInChildren<Button>().onClick.AddListener(() => { RestartLevel(); });
        }
    }
}
