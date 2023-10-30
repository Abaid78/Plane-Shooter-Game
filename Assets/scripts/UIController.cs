using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject settingPanel;
    public GameObject mainManuePanel;
    public GameObject healthMarket;
    public GameObject planeMarket;
    public GameObject coinsMakret;
    public Button showHealthMarketBtn;
    public Button showPlaneMarketBtn;
    public Button showCoinsMarketBtn;

    private enum MarketType
    {
        HealthMarket,
        PlaneMarket,
        CoinsMarket
    }

    private MarketType currentMarket;
    void Start()
    {
        shopPanel.SetActive(false);
        settingPanel.SetActive(false);
        mainManuePanel.SetActive(true);
        // Initialize the starting market
        currentMarket = MarketType.HealthMarket;
        UpdateMarketDisplay();
    }

    //Shop
    public void OpenShop()
    {
        shopPanel.SetActive(true);

    }
    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
    public void OpenHealthMarket()
    {
        currentMarket = MarketType.HealthMarket;
        UpdateMarketDisplay();
    }
    public void OpenPlaneMarket()
    {
        currentMarket = MarketType.PlaneMarket;
        UpdateMarketDisplay();
    }
    public void OpenCoinsMarket(){
        currentMarket=MarketType.CoinsMarket;
        UpdateMarketDisplay();
    }
    private void UpdateMarketDisplay()
    {
        // Disable  markets
        healthMarket.SetActive(false);
        planeMarket.SetActive(false);
        coinsMakret.SetActive(false);
        

        if (currentMarket == MarketType.HealthMarket)
        {
            healthMarket.SetActive(true);


        }
        else if (currentMarket == MarketType.PlaneMarket)
        {
            planeMarket.SetActive(true);

        }else if(currentMarket==MarketType.CoinsMarket){
            coinsMakret.SetActive(true);
        }
            //Change buttons Colors
        if (currentMarket == MarketType.PlaneMarket)
        {

            showPlaneMarketBtn.image.color = Color.green;
        }
        else
        {
            showPlaneMarketBtn.image.color = Color.white;
        }
        if (currentMarket == MarketType.HealthMarket)
        {

            showHealthMarketBtn.image.color = Color.green;
        }
        else
        {
            showHealthMarketBtn.image.color = Color.white;
        }
         if (currentMarket == MarketType.CoinsMarket)
        {

            showCoinsMarketBtn.image.color = Color.green;
        }
        else
        {
            showCoinsMarketBtn.image.color = Color.white;
        }
    }

    //Settings
    public void OpenSettings()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }


}

