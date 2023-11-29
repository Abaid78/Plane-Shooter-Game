using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionFlop : MonoBehaviour
{
    public Text coinsText;
    public CoinCounter coinCounter;
    // Start is called before the first frame update
    void OnEnable()
    {
        coinsText.text = "Collected Coins is: "+coinCounter.coins.ToString();
    }

   
}
