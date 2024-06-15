using UnityEngine;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        }

        if(Physics2D.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;
            Debug.Log("Clicked on: " + clickedObject.name);
        }
    }
}