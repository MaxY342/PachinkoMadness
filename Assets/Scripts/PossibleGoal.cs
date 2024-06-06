using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerMovement playerScript;
    
    public void Modify()
    {
        // change object colour to white
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponent<SpriteRenderer>().color == Color.white)
        {
            Debug.Log("Win!");
            playerScript = playerObject.GetComponent<PlayerMovement>();
            playerScript.ResetObject();
        }
        else if (collision.gameObject.CompareTag("Player") && GetComponent<SpriteRenderer>().color == Color.red)
        {
            Debug.Log("Lose!");
        }
    }
}
