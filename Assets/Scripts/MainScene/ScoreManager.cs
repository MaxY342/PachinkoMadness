using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PachinkoMadness.Data;

namespace PachinkoMadness.MainScene
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;
        public TextMeshProUGUI scoreText;

        private int score;
        private GameData gameData;

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
            gameData = SaveSystem.LoadGameData();
            ResetScore();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetScoreValue(int score)
        {
            gameData.scoreValue = score;
            SaveSystem.SaveGameData(gameData);
        }

        public int GetScoreValue()
        {
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
