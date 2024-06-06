using Unity.VisualScripting;
using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
    public GameObject targetObject;
    private PlayerMovement targetScript;
    
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
            targetScript = targetObject.GetComponent<PlayerMovement>();
            targetScript.ResetObject();
        }
        else if (collision.gameObject.CompareTag("Player") && GetComponent<SpriteRenderer>().color == Color.red)
        {
            Debug.Log("Lose!");
        }
    }
}
