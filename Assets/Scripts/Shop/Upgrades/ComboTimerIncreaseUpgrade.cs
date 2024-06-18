using UnityEngine;
using UnityEngine.UI;

public class ComboTimerIncreaseUpgrade : MonoBehaviour
{
    private float increaseRate = 1.5f;
    private float currentComboTimer = ComboManager.instance.GetComboTimer();
    public void IncreaseComboTimer()
    {
        ComboManager.instance.SetComboTimer(currentComboTimer + increaseRate);
    }
}
