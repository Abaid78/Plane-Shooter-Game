using System.IO;
using UnityEngine;

public class SaveSystem
{

    #region Coins Save and Load
    public static void SaveCoin(int coins)
    {
        CoinsData coinsData = new CoinsData(coins);
        string json = JsonUtility.ToJson(coinsData);
        string path = Application.persistentDataPath + "/GameData.json";
        File.WriteAllText(path, json);
    }
    public static CoinsData LoadCoins()
    {
        string path = Application.persistentDataPath + "/GameData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CoinsData loadCoins = JsonUtility.FromJson<CoinsData>(json);
            return loadCoins;
        }
        else
        {
            Debug.LogWarning("File is not exist " + path);
            return null;
        }

    }
    #endregion
}