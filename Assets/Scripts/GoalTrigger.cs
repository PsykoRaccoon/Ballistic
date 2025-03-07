using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ScoreManager.Instance.PlayerScored(gameObject);
            ball.ResetBall(); 
        }
    }
}
