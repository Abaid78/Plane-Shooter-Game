using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSuccessful : MonoBehaviour
{
    public Text coinsText;
    public CoinCounter coinCounter;
    public LevelProgress levelProgress;
    public Slider levelProgressSlider;
    public Text sliderValueText;
    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Collected Coins is: " + coinCounter.coins.ToString();
        levelProgressSlider.value = levelProgress.currentLevelProgress;
        sliderValueText.text = levelProgressSlider.value.ToString() + "%";

    }
}
