using UnityEngine;
using UnityEngine.UI;

public class HeartIncreaseUpgrade : MonoBehaviour
{
    private int increaseRate = 0;

    public void IncreaseHeart()
    {
        if(HealthManager.instance != null)
        {
            HealthManager.instance.AddHeart();
            Debug.Log("Heart purchased! New heart count: " + PlayerPrefs.GetInt("HeartCount"));
        }
        else
        {
            Debug.Log("HealthManager instance is not set.");
        }
    }
}