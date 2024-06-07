using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerMovement playerScript;
    public GameObject scoreManager;
    private ScoreManager scoreScript;
    public int scoreValue = 1;
    
    public void Modify()
    {
        // change object colour to white
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = playerObject.GetComponent<PlayerMovement>();
            scoreScript = scoreManager.GetComponent<ScoreManager>();
            if (GetComponent<SpriteRenderer>().color == Color.white)
            {
                playerScript.ResetObject();
                scoreScript.AddScore(scoreValue);
                Debug.Log("Win!");
            }
            else if (GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("Lose!");
            }
        }
    }
}
