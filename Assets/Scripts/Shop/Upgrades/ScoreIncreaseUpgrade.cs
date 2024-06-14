using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreaseUpgrade : MonoBehaviour
{
    public gameObject upgradeCard;
    private int increaseRate = 1;

    public void IncreaseScore(PossibleGoal possibleGoal)
    {
        possibleGoal.ScoreValue += increaseRate;
    }
}
