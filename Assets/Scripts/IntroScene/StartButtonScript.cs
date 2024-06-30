using UnityEngine;
using UnityEngine.SceneManagement;

namespace PachinkoMadness.IntroScene
{
    public class StartButtonScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public void OnStartButtonClick()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
