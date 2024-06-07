using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerMovement playerScript;
    public GameObject scoreManager;
    private ScoreManager scoreScript;
    public int scoreValue = 1;
    public GameObject comboManager;
    private ComboManager comboScript;
    public int comboValue = 1;
    
    public void MakeGoal()
    {
        // change object colour to white
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void MakeDanger()
    {
        // change object colour to red
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = playerObject.GetComponent<PlayerMovement>();
            scoreScript = scoreManager.GetComponent<ScoreManager>();
            comboScript = comboManager.GetComponent<ComboManager>();
            if (GetComponent<SpriteRenderer>().color == Color.white)
            {
                playerScript.ResetObject();
                scoreScript.AddScore(scoreValue);
                comboScript.AddCombo(comboValue);
                Debug.Log("Win!");
            }
            else if (GetComponent<SpriteRenderer>().color == Color.red)
            {
                comboScript.ResetCombo();
                Debug.Log("Lose!");
            }
        }
    }
}
