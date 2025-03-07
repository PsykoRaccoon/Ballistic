using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [System.Serializable]
    public class PlayerData
    {
        public GameObject player;
        public GameObject goal;
        public TextMeshProUGUI scoreText;
        public int score = 10;
    }

    public List<PlayerData> players = new List<PlayerData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void PlayerScored(GameObject goal)
    {
        foreach (PlayerData player in players)
        {
            if (player.goal == goal)
            {
                player.score--;
                if (player.score <= 0)
                {
                    player.score = 0;
                    player.player.SetActive(false); 
                    player.goal.SetActive(false);   
                }
                UpdateScoreUI();
                return;
            }
        }
    }

    private void UpdateScoreUI()
    {
        foreach (PlayerData player in players)
        {
            player.scoreText.text = player.score.ToString();
        }
    }
}