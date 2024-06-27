using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void SaveScoreValue(int score)
    {
        PlayerPrefs.SetInt("scoreValue", score);
    }

    public int GetScoreValue()
    {
        return PlayerPrefs.GetInt("scoreValue", 0); 
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
