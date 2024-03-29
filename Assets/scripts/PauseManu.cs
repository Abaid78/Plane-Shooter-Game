﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManu : MonoBehaviour
{
    public Text coinsText;
    public Text healthText;
    public CoinCounter coinsCounter;
    public PlayerHealth playerHealth;
    public Slider levelProgressSlider;
    public Text sliderValueText;
    public LevelProgress levelProgress;
    // Start is called before the first frame update
    void OnEnable()
    {
        coinsText.text = "Collected Coins is: "+coinsCounter.coins.ToString();
        healthText.text = "Health You Have: "+playerHealth.currentHealth.ToString();
        LevelProgress();
    }
    void LevelProgress()
    {
        levelProgressSlider.value = (int)levelProgress.CurrentLevelProgress;
        sliderValueText.text = levelProgressSlider.value.ToString() + "%";
    }
   
}
