
using UnityEngine;
using UnityEngine.UI;

public class PurchaseHealth : MonoBehaviour
{
    public int totalCoins;
    public Text totalHealthText;
    public Messages messageScript;
    public int getingHealth_1;
    public int cost_1;
    public int getHealthAmount_2;
    public int coinsPriceAmount_2;
    public int getHealthAmount_3;
    public int coinsPriceAmount_3;
    void OnEnable()
    {
        CoinsData coinsData = SaveSystem.LoadCoins();
        totalCoins = coinsData.coins;
        HealthYouHave();
    }
    void SaveAddHealth(float amount)
    {
        //use that Method otherwis loss all previous health and set a new getHealthAmount that is 0,2or3 and so ever; not use PlayerPrefs.SetFloat("Health", getHealthAmount_1);
        float health = PlayerPrefs.GetFloat("Health");
        health += amount;
        PlayerPrefs.SetFloat("Health", health);
        PlayerPrefs.Save();
        HealthYouHave();
    }
    void SaveAndLoadCoins(int amount)
    {
        CoinsData coinsData = SaveSystem.LoadCoins();
        totalCoins = coinsData.coins;
        totalCoins -= amount;
        SaveSystem.SaveCoin(totalCoins);
    }
    public void GetHealth_1()
    {
        if (totalCoins >= cost_1)
        {
            SaveAndLoadCoins(cost_1);
            SaveAddHealth(getingHealth_1);
            messageScript.SucssesfullyPerchaseHealth();
        }
        else
        {
            Debug.Log(cost_1-totalCoins+ " => MORE COINS TO GET HEALTH");
            messageScript.FailToPerchaseHealth(totalCoins, cost_1);
        }
    }
    public void GetHealth_2()
    {
        if (totalCoins >= coinsPriceAmount_2)
        {

            SaveAndLoadCoins(coinsPriceAmount_2);
            SaveAddHealth(getHealthAmount_2);
        }
        else
        {
            Debug.Log(coinsPriceAmount_2 - totalCoins + " => MORE COINS TO GET HEALTH");
        }
    }
    public void GetHealth_3()
    {
        if (totalCoins >= coinsPriceAmount_3)
        {

            SaveAndLoadCoins(coinsPriceAmount_3);
            SaveAddHealth(getHealthAmount_3);
        }
        else
        {
            Debug.Log(coinsPriceAmount_3 - totalCoins + " => MORE COINS TO GET HEALTH");
        }
    }
    //Show total Health also update UI
    public void HealthYouHave()
    {
        float health = PlayerPrefs.GetFloat("Health");
        totalHealthText.text = "Health You Have "+health.ToString();
    }
}
