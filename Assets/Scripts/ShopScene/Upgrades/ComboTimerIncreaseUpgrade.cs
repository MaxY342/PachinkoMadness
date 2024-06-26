using UnityEngine;
using UnityEngine.UI;

namespace PachinkoMadness.ShopScene.Upgrades
{
    public class ComboTimerIncreaseUpgrade : MonoBehaviour
    {
        private float increaseRate = 1.5f;
        public void IncreaseComboTimer()
        {
            float currentComboTimer = ComboManager.instance.GetComboTimer();
            ComboManager.instance.SetComboTimer(currentComboTimer + increaseRate);
        }
    }
}
