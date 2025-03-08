using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject player2, player3, player4; 
    public AIPlayer player2AI, player3AI, player4AI; 
    public PlayerMovement player2Movement, player3Movement, player4Movement;

    public void SetPlayerCount(int playerCount)
    {
        switch (playerCount)
        {
            case 2:
                ActivatePlayer(player2, player2Movement, player2AI, true);
                ActivatePlayer(player3, player3Movement, player3AI, true);
                ActivatePlayer(player4, player4Movement, player4AI, false);
                break;
            case 3:
                ActivatePlayer(player2, player2Movement, player2AI, true);
                ActivatePlayer(player3, player3Movement, player3AI, true);
                ActivatePlayer(player4, player4Movement, player4AI, false);
                break;
            case 4:
                ActivatePlayer(player2, player2Movement, player2AI, true);
                ActivatePlayer(player3, player3Movement, player3AI, true);
                ActivatePlayer(player4, player4Movement, player4AI, true);
                break;
            default:
                DeactivateAllPlayers();
                break;
        }
    }

    private void ActivatePlayer(GameObject player, PlayerMovement playerMovement, AIPlayer playerAI, bool isHuman)
    {
        player.SetActive(true); 

        if (isHuman)
        {
            playerMovement.enabled = true;
            playerAI.enabled = false;
        }
        else
        {
            playerMovement.enabled = false;
            playerAI.enabled = true;
        }
    }

    private void DeactivateAllPlayers()
    {
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
    }
}
