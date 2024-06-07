using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    private int combo;
    // Start is called before the first frame update
    void Start()
    {
        combo = 0;
        UpdateComboText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int comboValue)
    {
        combo += comboValue;
        Debug.Log("Combo added: " + comboValue);
        UpdateComboText();
    }
    private void UpdateComboText()
    {
        comboText.text = "Combo: " + combo;
    }
}
