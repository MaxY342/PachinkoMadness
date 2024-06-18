using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public GameObject firePreFab;
    public Transform canvasTransform;
    public static ComboManager instance;

    private int combo;
    private GameObject currentFlame;
    private Coroutine comboResetCoroutine;
    private float comboDuration = 5f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

        if (comboResetCoroutine != null)
        {
            StopCoroutine(comboResetCoroutine);
        }
        comboResetCoroutine = StartCoroutine(ComboResetTimer());
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

    public int Increment()
    {
        int multiplier = 0;
        float positiveInf = float.PositiveInfinity;
        for (int i = 0; i < positiveInf; i += 5)
        {
            if (combo < i)
            {
                multiplier = i - 5;
                break;
            }
        }
        if (multiplier > 0)
        {
            multiplier /= 5;
        }
        return multiplier;
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

    private IEnumerator ComboResetTimer()
    {
        yield return new WaitForSeconds(comboDuration);
        ResetCombo();
    }
}
