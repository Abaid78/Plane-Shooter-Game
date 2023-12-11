using UnityEngine;
using UnityEngine.UI;

public class CoinsMarketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int watchAdCoins = 10;

    public Text coinText;
    public GameData gameData;
    private int coins;
    public GameObject warningPanel;
    public Messages messagesScript;

    private void OnEnable()
    {
        CoinsData data = SaveSystem.LoadCoins();
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
        messagesScript.GetCoinsSussesfully(10);
    }
}