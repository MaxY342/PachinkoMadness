using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PachinkoMadness.Data;

namespace PachinkoMadness.MainScene
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f;
        private bool falling = false;
        private Rigidbody2D rb;
        private Vector2 initialPosition;
        private Quaternion initialRotation;

        void Start()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
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
                GameData gameData = SaveSystem.LoadGameData();
                gameData.falling = true;
                SaveSystem.SaveGameData(gameData);
                rb.gravityScale = 1;
            }
        }

        public void ResetObject()
        {
            // Reset position
            transform.position = initialPosition;
            transform.rotation = initialRotation;

            // Reset falling status
            falling = false;
            GameData gameData = SaveSystem.LoadGameData();
            gameData.falling = false;
            SaveSystem.SaveGameData(gameData);

            // Stop any existing movement
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.gravityScale = 0;
        }
    }
}