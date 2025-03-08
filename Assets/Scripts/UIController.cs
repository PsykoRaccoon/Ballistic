using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerSelector playerSelector;
    public GameObject canvasMenu, ball;

    public void SelectOnePlayer()
    {
        canvasMenu.SetActive(false);
        ball.SetActive(true);
    }

    public void SelectTwoPlayers()
    {
        playerSelector.SetPlayerCount(2);
        canvasMenu.SetActive(false);
        ball.SetActive(true);
    }

    public void SelectThreePlayers()
    {
        playerSelector.SetPlayerCount(3);
        canvasMenu.SetActive(false);
        ball.SetActive(true);
    }

    public void SelectFourPlayers()
    {
        playerSelector.SetPlayerCount(4);
        canvasMenu.SetActive(false);
        ball.SetActive(true);
    }
}

