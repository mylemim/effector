using UnityEngine;
using System.Collections;

public class UiManager : MonoBehaviour
{
    GameObject winNotification;
    GameObject loseNotification;

    public void InitUi()
    {
        winNotification = GameObject.Find("PlayerWon");
        loseNotification = GameObject.Find("PlayerLost");

        winNotification.SetActive(false);
        loseNotification.SetActive(false);
    }

    public void PlayerWon()
    {
        if (!loseNotification.activeSelf)
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
