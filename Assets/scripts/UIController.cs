using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainManuePanel;

    public GameObject shopPanel;
    public GameObject settingPanel;
    public GameObject healthMarket;
    public GameObject planeMarket;
    public GameObject coinsMakret;
    public GameObject levelSelections;

    [Header("Canvas Groups")]
    public CanvasGroup shopPanelCG;
    public CanvasGroup settingPanelCG;
    public CanvasGroup healthMarketCG;
    public CanvasGroup planeMarketCG;
    public CanvasGroup coinsMarketCG;
    public CanvasGroup levelSelectionCG;

    [Header("Other Components")]
    public UIAnimations uiAnimations;
    public Button showHealthMarketBtn;
    public Button showPlaneMarketBtn;
    public Button showCoinsMarketBtn;

    [Header("Animation Settings")]
    public float animDuration = 0.4f;

    private enum MarketType
    {
        HealthMarket,
        PlaneMarket,
        CoinsMarket
    }

    private MarketType currentMarket;

    private void OnEnable()
    {
        shopPanel.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        mainManuePanel.SetActive(true);
        levelSelections.SetActive(false);
        // Initialize the starting market
        currentMarket = MarketType.HealthMarket;
        UpdateMarketDisplay();
    }

    //Shop
    public async void OpenShop()
    {
        shopPanel.SetActive(true);
        await uiAnimations.FadeInAsync(shopPanelCG, animDuration);
    }

    public async void CloseShop()
    {
        await uiAnimations.FadeOutAsync(shopPanelCG, animDuration);
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

    public void OpenCoinsMarket()
    {
        currentMarket = MarketType.CoinsMarket;
        UpdateMarketDisplay();
    }

    private async void UpdateMarketDisplay()
    {
        // Disable markets
        uiAnimations.FadeOut(healthMarketCG, animDuration);
        uiAnimations.FadeOut(planeMarketCG, animDuration);
        uiAnimations.FadeOut(coinsMarketCG, animDuration);

        // Enable and animate the selected market
        switch (currentMarket)
        {
            case MarketType.HealthMarket:
                healthMarket.SetActive(true);
                await uiAnimations.FadeInAsync(healthMarketCG, animDuration);
                coinsMakret.SetActive(false);
                planeMarket.SetActive(false);
                break;

            case MarketType.PlaneMarket:
                planeMarket.SetActive(true);
                await uiAnimations.FadeInAsync(planeMarketCG, animDuration);
                healthMarket.SetActive(false);
                coinsMakret.SetActive(false);
                break;

            case MarketType.CoinsMarket:
                coinsMakret.SetActive(true);
                await uiAnimations.FadeInAsync(coinsMarketCG, animDuration);
                healthMarket.SetActive(false);
                planeMarket.SetActive(false);
                break;
        }

        // Change button colors
        switch (currentMarket)
        {
            case MarketType.PlaneMarket:
                showPlaneMarketBtn.image.color = Color.cyan;
                break;

            case MarketType.HealthMarket:
                showHealthMarketBtn.image.color = Color.cyan;
                break;

            case MarketType.CoinsMarket:
                showCoinsMarketBtn.image.color = Color.cyan;
                break;
        }
    }


    //Settings
    public async void OpenSettings()
    {
        settingPanel.gameObject.SetActive(true);
        await uiAnimations.FadeInAsync(settingPanelCG, animDuration);
    }

    public async void CloseSettings()
    {
        await uiAnimations.FadeOutAsync(settingPanelCG, animDuration);
        settingPanel.gameObject.SetActive(false);
    }

    public async void CloseLevelselections()
    {
        await uiAnimations.FadeOutAsync(levelSelectionCG, animDuration);
        levelSelections.SetActive(false);
    }
    //open level sellections
    public async void Play()
    {
        levelSelections.SetActive(true);
        await uiAnimations.FadeInAsync(levelSelectionCG, animDuration);
    }

    public void Quit()
    {
        Application.Quit();
    }
}