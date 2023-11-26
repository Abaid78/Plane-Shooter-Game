using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinCounterText;
    public int coins = 0;
    public void AddCoins()
    {
        coins+=1;
        int savedCoins = LoadCoins();
        savedCoins += 1;
        SaveSystem.SaveCoin(savedCoins);
        
        coinCounterText.text = coins.ToString();
    }
    public int LoadCoins()
    {
        CoinsData data = SaveSystem.LoadCoins();
        return data.coins;
    }
    
}