using UnityEngine;
using UnityEngine.UI;

namespace PachinkoMadness.ShopScene.Upgrades
{
    public class ScoreIncreaseUpgrade : MonoBehaviour
    {

        private int increaseRate = 1;
        public void IncreaseScore()
        {
            int currentScoreValue = ScoreManager.instance.GetScoreValue();
            ScoreManager.instance.SetScoreValue(currentScoreValue + increaseRate);
        }
    }
}
