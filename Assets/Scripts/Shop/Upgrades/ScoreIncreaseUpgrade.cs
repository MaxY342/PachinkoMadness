using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreaseUpgrade : MonoBehaviour
{

    private int increaseRate = 1;
    private int currentScoreValue = ScoreManager.instance.GetScoreValue();
    public void IncreaseScore()
    {
        ScoreManager.instance.SaveScoreValue(currentScoreValue + increaseRate);
    }
}
