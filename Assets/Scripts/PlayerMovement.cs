using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private bool falling = false;
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    void Update()
    {
        if (!falling)
        {
            // get user left - right input
            float horizontalInput = Input.GetAxis("Horizontal");
    
            // calculate new position
            Vector2 newPosition = new Vector2(horizontalInput * speed * Time.deltaTime, 0);
    
            // transform to new position
            transform.Translate(newPosition);
        }
        if (Input.GetKeyDown("space"))
        {
            falling = true;
            rb.gravityScale = 1;
        }
    }
    public void ResetObject()
    {
        transform.position = initialPosition;
        falling = false;
        rb.gravityScale = 0;
    }
}
