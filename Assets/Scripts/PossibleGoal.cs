using Unity.VisualScripting;
using UnityEngine;

public class PossibleGoal : MonoBehaviour
{
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
        }
        else if (collision.gameObject.CompareTag("Player") && GetComponent<SpriteRenderer>().color == Color.red)
        {
            Debug.Log("Lose!");
        }
    }
}