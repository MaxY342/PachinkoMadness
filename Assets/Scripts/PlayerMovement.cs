using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            // move to new position
            transform.Translate(newPosition);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            falling = true;
            rb.gravityScale = 1;
        }
    }

    public void ResetObject()
    {
        // Reset position
        transform.position = initialPosition;

        // Reset falling status
        falling = false;

        // Stop any existing movement
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }
}