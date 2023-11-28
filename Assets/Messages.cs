using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public UIAnimations uiAnimations;
    public GameObject messagePanel;
    public RectTransform rectTransMessagePanel;
    public Image messagePanelImag;
    public CanvasGroup messagePanelCG;
    public Text messageText;
    public Text titleText;
    public Color failourColor;
    public float animDuration = 0.5f;

    public void GetCoinsSussesfully(int coins)
    {
        string title = "Congratulations!";
        string message = $"You've Successfully Get Coins!\n\n<color=cyan>Coins: {coins}</color>\n\nStay strong, and keep conquering those challenges!";

        // Assuming you have a Text component attached to the same GameObject
        if (messageText != null)
        {
            messageText.text = message;
        }
        if (titleText != null)
        {
            titleText.text = title;
        }
        else
        {
            Debug.LogError($"Assign the Title Text to the Field on the GameObject: {gameObject.name}");
        }
        ActiveMessagePanel();
    }

    public void SucssesfullyPerchaseHealth()
    {
        string title = "Congratulations!";
        string message = $"You've Successfully Purchased Health!\n\nStay strong, and keep conquering those challenges!";

        // Assuming you have a Text component attached to the same GameObject
        if (messageText != null)
        {
            messageText.text = message;
        }
        if (titleText != null)
        {
            titleText.text = title;
        }
        else
        {
            Debug.LogError($"Assign the Title Text to the Field on the GameObject: {gameObject.name}");
        }
        ActiveMessagePanel();
    }

    public void FailToPerchaseHealth(int currentCoins, int healthCost)
    {
        string title = "Notification!";
        messagePanelImag.color = failourColor;
        string message = $"Insufficient Coins for Health Purchase\n\n" +
            $"Current Coins: <color=blue>{currentCoins}</color>\n" +
            $"Health Cost: <color=red>{healthCost}</color>\n" +
            "You're on the right track! Keep playing, completing challenges, and earning those coins or <color=blue><i> Watche the Adds</i></color>. Your determination is unlocking new opportunities.";

        // Assuming you have a Text component attached to the same GameObject
        if (messageText != null)
        {
            messageText.text = message;
        }
        if (titleText != null)
        {
            titleText.text = title;
        }
        else
        {
            Debug.LogError($"Assign the Title Text to the Field on the GameObject: {gameObject.name}");
        }
        OnFailure();
    }

    public void SussesfullyPlanePerchase(string planeName, int coinsSpent)
    {
        string title = "Congratulations! 🎉";

        string message = $" You've successfully purchased the <b><i>{planeName}</i></b>!\n\n" +
            $"Coins Spent: <color=orange>{coinsSpent}</color>\n\n" +
            "Get ready to soar through the skies with your new <i>Super Jet</i>. Feel the thrill of high-speed adventures and conquer the skies!\n\n" +
            "Thank you for your purchase! We appreciate your support in making your gaming experience extraordinary.";

        // Assuming you have a Text component attached to the same GameObject
        if (messageText != null)
        {
            messageText.text = message;
        }
        if (titleText != null)
        {
            titleText.text = title;
        }
        else
        {
            Debug.LogError($"Assign the Title Text to the Field on the GameObject: {gameObject.name}");
        }
        ActiveMessagePanel();
    }

    public void PlanePerchaseFailure(string planeName, int currentCoins, int planeCost)
    {
        messagePanelImag.color = failourColor;
        string title = "Transaction Failed!";
        string message = $"Insufficient Coins to Purchase the <b><i>{planeName}</i></b>.\n" +
            $"Current Coins: <color=green>{currentCoins}</color>\n" +
            $"Plane Cost: <color=red>{planeCost}</color>\n" +
            "Oh no! It seems like your dreams of flying the <i>Super Jet</i>. No worries, though! Keep playing,completing challenges,or<color=blue><i> Watche the Adds</i></color>, and collecting those coins. You'll be soaring through the skies in no time!";

        // Assuming you have a Text component attached to the same GameObject
        if (messageText != null)
        {
            messageText.fontSize = 58;
            messageText.text = message;
        }
        else
        {
            Debug.LogError($"Please assign the Text Component on the GameObject: {gameObject.name}");
        }

        if (titleText != null)
        {
            titleText.text = title;
        }
        else
        {
            Debug.LogError($"Assign the Title Text to the Field on the GameObject: {gameObject.name}");
        }
        OnFailure();
    }

    public async void MessageOKBtn()
    {
        await uiAnimations.FadeOutAsync(messagePanelCG, animDuration);
        messagePanel.SetActive(false);
    }

    public void ActiveMessagePanel()
    {
        messagePanel.SetActive(true);
        uiAnimations.FadeIn(messagePanelCG, animDuration);
    }

    public void OnFailure()
    {
        messagePanel.SetActive(true);
        uiAnimations.Shake(rectTransMessagePanel);
        uiAnimations.FadeIn(messagePanelCG, animDuration);
    }
}