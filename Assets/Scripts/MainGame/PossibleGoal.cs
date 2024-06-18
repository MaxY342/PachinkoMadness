using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PossibleGoal : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerMovement playerScript;
    private int scoreValue = ScoreManager.instance.GetScoreValue();
    private int initialScoreValue;
    public int comboValue = 1;
    private DeathScreenManager deathScreenManager;

    void Start()
    {
        initialScoreValue = scoreValue;

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

        deathScreenManager = FindObjectOfType<DeathScreenManager>();
    }

    void Update()
    {

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
                scoreValue = initialScoreValue + ComboManager.instance.Increment();
                playerScript.ResetObject();
                ScoreManager.instance.AddScore(scoreValue);
                ComboManager.instance.AddCombo(comboValue);
                GoalManager.instance.SelectAndModifyGoals();
                Debug.Log("Win!");
            }
            else if (GetComponent<SpriteRenderer>().color == Color.red)
            {
                HealthManager.instance.RemoveHeart();
                if (HealthManager.instance.DeathCheck())
                {
                    deathScreenManager.ShowDeathScreen();
                }
                ComboManager.instance.ResetCombo();
                playerScript.ResetObject();
                Debug.Log("Lose!");
            }
        }
    }
}
