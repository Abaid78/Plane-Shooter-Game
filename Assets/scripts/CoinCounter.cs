using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinCounterText;
    public Text coinsText;
    int coins=0;
    void Update()
    {
        coinCounterText.text=coins.ToString();
        coinsText.text="Coins : "+coins.ToString();
        
    }
    public void AddCoins(){
        coins++;
    }
    

}
