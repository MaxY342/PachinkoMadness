using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }
    void Update()
    {
        // get user left - right input
        float horizontalInput = Input.GetAxis("Horizontal");

        // get the current position
        Vector2 currentPosition = transform.position;

        // calculate new position
        Vector2 newPosition = currentPosition + new Vector2(horizontalInput * speed * Time.deltaTime, 0);

        // transform to new position
        transform.position = newPosition;
    }
}
