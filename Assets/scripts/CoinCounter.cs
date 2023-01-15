using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinCounterText;
    int coins=0;
    void Update()
    {
        coinCounterText.text=coins.ToString();
        
    }
    public void AddCoins(){
        coins++;
    }

}
