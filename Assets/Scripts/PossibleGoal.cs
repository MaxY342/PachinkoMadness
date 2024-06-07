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

    void Start()
    {
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<PlayerMovement>();
            if (playerScript == null)
            {
                Debug.LogError("PlayerMovement script not found on playerObject!");
            }
        }
        else
        {
            Debug.LogError("playerObject not assigned in the Inspector!");
        }

        if (scoreManager != null)
        {
            scoreScript = scoreManager.GetComponent<ScoreManager>();
            if (scoreScript == null)
            {
                Debug.LogError("ScoreManager script not found on scoreManager object!");
            }
        }
        else
        {
            Debug.LogError("scoreManager not assigned in the Inspector!");
        }

        if (comboManager != null)
        {
            comboScript = comboManager.GetComponent<ComboManager>();
            if (comboScript == null)
            {
                Debug.LogError("ComboManager script not found on comboManager object!");
            }
        }
        else
        {
            Debug.LogError("comboManager not assigned in the Inspector!");
        }
    }
    
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
