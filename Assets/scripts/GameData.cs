using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Prefabs")]
    public List<GameObject> prefabs = new List<GameObject>();

    [Header("Index and Statistics")]
    public int listIndex;
    public int coins;
    public float health;
    public bool autoFire = false;

    [Header("Purchase and Selection")]
    public bool[] isPurchased = { false };
    public bool isSelected;
    public string selectButtonText = "Selected";
    public string planePriceText = "You Have Purchased";

    [Header("Level Selections")]
    public int selectedLevelIndex = 0; // Store the selected level.
    public float[] LevelProgressFill;
    public bool[] unLocked = { false };
    public string unLockText = "UNLOCK";

    // Encapsulated property for Coins
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    // Encapsulated property for Health
    public float Health
    {
        get { return health; }
        set { health = value; }
    }


    // Method to add coins
    public void AddCoins(int amount)
    {
        Coins += amount;
    }

    // Method to subtract coins
    public void SubtractCoins(int amount)
    {
        Coins -= amount;
    }

    // Method to add health
    public void AddHealth(int amount)
    {
        Health += amount;
    }

    public float CalculateCumulativeProgress(float[] levelProgressArray, int levelsToCalculate)
    {
        float cumulativeProgress = 0f;
        for (int i = 0; i < levelsToCalculate; i++)
        {
            cumulativeProgress += levelProgressArray[i];
        }
        return cumulativeProgress;
    }
}
