using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MyGame

namespace MyGame.MainGame
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;
        public TextMeshProUGUI scoreText;
        private int score;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetScore();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetScoreValue(int score)
        {
            GameData gameData = SaveSystem.LoadGameData();
            gameData.scoreValue = score;
            SaveSystem.SaveGameData(gameData);
        }

        public int GetScoreValue()
        {
            GameData gameData = SaveSystem.LoadGameData();
            return gameData.scoreValue;
        }

        public void AddScore(int points)
        {
            score += points;
            Debug.Log("Score added: " + points);
            UpdateScoreText();
        }
        
        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + score;
        }

        public void ResetScore()
        {
            score = 0;
            UpdateScoreText();
        }
    }
}
