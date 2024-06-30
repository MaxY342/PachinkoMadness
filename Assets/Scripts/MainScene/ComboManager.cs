using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using PachinkoMadness.Data;

namespace PachinkoMadness.MainScene
{
    public class ComboManager : MonoBehaviour
    {
        public TextMeshProUGUI comboText;
        public GameObject firePreFab;
        public Transform canvasTransform;
        public Slider comboTimerSlider;
        public static ComboManager instance;

        private int combo;
        private GameObject currentFlame;
        private Coroutine comboResetCoroutine;
        private float comboDuration;
        private GameData gameData;

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
            LoadGameData();
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
            if (comboResetCoroutine != null)
            {
                StopCoroutine(comboResetCoroutine);
                comboResetCoroutine = null;
            }
            ResetComboTimerSlider();
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
            float timeRemaining = comboDuration;
            comboTimerSlider.maxValue = comboDuration;
            comboTimerSlider.value = comboDuration;
            
            while (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                comboTimerSlider.value = timeRemaining;
                yield return null;
            }
            
            gameData = SaveSystem.LoadGameData();
            if (!gameData.falling)
            {
                ResetCombo();
            }
        }

        private void ResetComboTimerSlider()
        {
            if (comboTimerSlider != null)
            {
                comboTimerSlider.value = 0;
            }
        }

        public void SetComboTimer(float time)
        {
            gameData.comboTimer = time;
            SaveSystem.SaveGameData(gameData);
        }

        public float GetComboTimer()
        {
            return gameData.comboTimer;
        }

        private void LoadGameData()
        {
            gameData = SaveSystem.LoadGameData();
            comboDuration = GetComboTimer();
        }
    }
}
