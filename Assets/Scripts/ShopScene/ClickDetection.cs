using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace PachinkoMadness.ShopScene
{
    public class ClickDetection : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if(hit.collider != null)
                {
                    GameObject clickedObject = hit.collider.gameObject;
                    Debug.Log("Clicked on: " + clickedObject.name);
                    if (clickedObject.name == "ScoreIncreaseUpgrade")
                    {
                        ScoreIncreaseUpgrade scoreIncreaseUpgrade = clickedObject.GetComponent<ScoreIncreaseUpgrade>();
                        if (scoreIncreaseUpgrade != null)
                        {
                            scoreIncreaseUpgrade.IncreaseScore();
                        }
                    }

                    else if(clickedObject.name == "HeartIncreaseUpgrade")
                    {
                        HeartIncreaseUpgrade heartIncreaseUpgrade = clickedObject.GetComponent<HeartIncreaseUpgrade>();
                        if (heartIncreaseUpgrade != null)
                        {
                            heartIncreaseUpgrade.IncreaseHeart();
                        }
                    }
                }
            }
        }
    }
}
