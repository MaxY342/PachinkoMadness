using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreaseUpgrade : MonoBehaviour
{

    private int increaseRate = 1;
    public void IncreaseScore()
    {
        int currentScoreValue = ScoreManager.instance.GetScoreValue();
        ScoreManager.instance.SaveScoreValue(currentScoreValue + increaseRate);
    }
}
