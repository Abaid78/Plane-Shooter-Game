using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsMarketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int watchAdCoins = 10;
    public Text coinText;
    public GameData gameData;
    int coins;
    public GameObject warningPanel;
    void OnEnable()
    {
        CoinsData data = SaveSystem.LoadCoins();
        Debug.Log(data);
        coins = data.coins;
    }
    private void Update()
    {
        CoinsDisplay();
    }
    public void CoinsDisplay()
    {
        coinText.text = coins.ToString();
    }
    public void WatchAdBtn()
    {
        coins += 10;
        SaveSystem.SaveCoin(coins);
        CoinsDisplay();
    }
}
