using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public GameObject firePreFab;
    public Transform canvasTransform;

    private int combo;
    private GameObject currentFlame;
    // Start is called before the first frame update
    void Start()
    {
        ResetCombo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCombo(int comboValue)
    {
        combo += comboValue;
        Debug.Log("Combo added: " + comboValue);
        UpdateComboText();
        ShowFlame();
    }

    private void UpdateComboText()
    {
        comboText.text = "Combo: " + combo + "x";
    }

    public void ResetCombo()
    {
        combo = 0;
        UpdateComboText();
        HideFlame();
    }

    private void ShowFlame()
    {
        if (currentFlame == null)
        {
            currentFlame = Instantiate(firePreFab, canvasTransform);
        }
        currentFlame.SetActive(true);
    }

    private void HideFlame()
    {
        if (currentFlame != null)
        {
            currentFlame.SetActive(false);
        }
    }
}
