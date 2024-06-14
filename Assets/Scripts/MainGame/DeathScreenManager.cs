using System.Collections
using UnityEngine
using UnityEngine.UI

public class DeathScreenManager : Monobehaviour
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
        
    }
}
