using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public GameObject playerObject;
        public GameObject goal;
        public GameObject wall;
        public TextMeshProUGUI scoreText;
        public int score;
    }

    public List<PlayerData> players;

    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerScored(GameObject goal)
    {
        foreach (var player in players)
        {
            if (player.goal == goal)
            {
                player.score--;
                UpdateScoreUI(player);
                CheckForElimination(player);
                break;
            }
        }
    }

    private void UpdateScoreUI(PlayerData player)
    {
        player.scoreText.text = player.score.ToString();
    }

    private void CheckForElimination(PlayerData player)
    {
        if (player.score <= 0)
        {
            player.playerObject.SetActive(false);
            player.goal.SetActive(false);
            player.wall.SetActive(true);
            CheckForWinner();
        }
    }

    private void CheckForWinner()
    {
        int activePlayers = 0;
        foreach (var player in players)
        {
            if (player.playerObject.activeSelf)
                activePlayers++;
        }

        if (activePlayers == 1)
        {
            Debug.Log("ayuda por favor");
        }
    }
}
