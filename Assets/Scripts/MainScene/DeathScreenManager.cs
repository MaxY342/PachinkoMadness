using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PachinkoMadness.MainScene
{
    public class DeathScreenManager : MonoBehaviour
    {
        public GameObject deathScreen;
        private float displayTime = 3.0f;

        void Start()
        {
            deathScreen.SetActive(false);
        }
        public void ShowDeathScreen()
        {
            StartCoroutine(DisplayDeathScreen());
        }

        private IEnumerator DisplayDeathScreen()
        {
            deathScreen.SetActive(true);

            yield return new WaitForSeconds(displayTime);

            deathScreen.SetActive(false);

            SceneManagement.LoadScene("ShopScene");
        }
    }
}
