using UnityEngine;
using UnityEngine.UI;

public class ComboTimerIncreaseUpgrade : MonoBehaviour
{
    private float increaseRate = 1.5f;
    private float currentComboTimer = ScoreManager.instance.GetComboTimer();
    public void IncreaseComboTimer()
    {
        ScoreManager.instance.SetComboTimer(currentComboTimer + increaseRate);
    }
}
