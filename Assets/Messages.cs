using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public UIAnimations uiAnimations;
    public RectTransform messagePanel;
    public Image messagePanelImag;
    public CanvasGroup messagePanelCG;
    public Text messageText;
    public Text titleText;
    public Color failourColor;
    private void Start()
    {
        SucssesfullyPerchaseHealth();
    }
    public void SucssesfullyPerchaseHealth()
    {
        int health = 222;
        int coins = 333;
        string title = "Congratulations!";
        string message = $"You've Successfully Purchased Health!\n\n<color=cyan>Health: {health}</color>\n<color=cyan>Coins: {coins}</color>\n\nStay strong, and keep conquering those challenges!";

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
    }
    public void FailToPerchaseHealth()
    {
        int currentCoins = 150;
        int healthCost = 200;
        string title = "Notification!";
        messagePanelImag.color = failourColor;
        string message = $"Insufficient Coins for Health Purchase\n\n" +
            $"Current Coins: <color=blue>{currentCoins}</color>\n" +
            $"Health Cost: <color=red>{healthCost}</color>\n\n" +
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
    }
    public void SussesfullyPlanePerchase()
    {
        string planeName = "Super Jet";
        string title = "Congratulations! 🎉";
        int coinsSpent = 500;
        
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
    }
    public void PlanePerchaseFailure()
    {
        string planeName = "Super Jet";
        int currentCoins = 300;
        int planeCost = 500;
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
        

    }

}
