using UnityEngine;
using UnityEngine.UI;

public class ComboTimerIncreaseUpgrade : MonoBehaviour
{
    private float increaseRate = 1.5f;
    float currentComboTimer = ScoreManager.instance.GetComboTimer();
    ScoreManager.instance.SetComboTimer(currentComboTimer + increaseRate)
}
