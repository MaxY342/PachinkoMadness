using Unity.VisualScripting;
using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
    public gameObject targetObject;
    
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
            PlayerMovement targetScript = targetObject.GetComponent<PlayerMovement>();
            targetObject.transform.position = new Vector2(0, 0);
            targetScript.falling = false;
        }
        else if (collision.gameObject.CompareTag("Player") && GetComponent<SpriteRenderer>().color == Color.red)
        {
            Debug.Log("Lose!");
        }
    }
}
