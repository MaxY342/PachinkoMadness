using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreaseUpgrade : MonoBehaviour
{

    private int increaseRate = 1;

    public void IncreaseScore()
    {
        PossibleGoal[] possibleGoals = FindObjectsOfType<PossibleGoal>();
        foreach (PossibleGoal goal in possibleGoals)
        {
            goal.ScoreValue += increaseRate;
        }
    }
}
