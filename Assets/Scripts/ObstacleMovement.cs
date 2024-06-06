using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 1;
    private float initialPosition;
    private bool movingRight;
    public float switchProb = 0.0001f;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.x;
        movingRight = Random.Range(0,2) == 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        if (movingRight)
        {
            transform.position = currentPosition + new Vector2(speed * Time.deltaTime, 0);
            if (currentPosition.x > initialPosition + 0.4f && Random.value < switchProb)
            {
                switchProb = 0.0001f;
                movingRight = false;
            }
            else if (currentPosition.x > initialPosition)
            {
                switchProb += 0.0001f;
            }
        }
        else
        {
            transform.position = currentPosition + new Vector2(-speed * Time.deltaTime, 0);
            if (currentPosition.x < initialPosition + 0.4f && Random.value < switchProb)
            {
                switchProb = 0.0001f;
                movingRight = true;
            }
            else if (currentPosition.x < initialPosition)
            {
                switchProb += 0.0001f;
            }
        }
    }
}
