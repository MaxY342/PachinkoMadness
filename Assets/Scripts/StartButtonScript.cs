using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
