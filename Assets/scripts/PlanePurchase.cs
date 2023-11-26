using UnityEngine;
using UnityEngine.UI;

public class PlanePurchase : MonoBehaviour
{
    // Public variables accessible in the Unity Editor
    public int planeID;
    public int price = 1;
    public Text priceText;
    public Button equipBtn;
    public Image selectedBtnImg; // Image component for the selected state
    public Text equipBtnText;

    // Private variables for internal use
    private int isPurchased = 0;
    private int coins;

    // Start is called before the first frame update
    void OnEnable()
    {
        // Load the purchase state of the plane from PlayerPrefs
        isPurchased = PlayerPrefs.GetInt("Plane_" + planeID + "_isPurchased");

        // Update UI based on the purchase state
        if (isPurchased == 1)
        {
            priceText.text = "PURCHASED";
            equipBtnText.text = "Select";
        }
        else
        {
            priceText.text = price.ToString();
            equipBtnText.text = "Equip";
        }

        // Automatically select the plane if it was the previously selected one
        if (planeID == PlayerPrefs.GetInt("SelectedPlane"))
        {
            SelectPlane();
        }
    }

    // Handles the purchase logic for the plane
    public void PurchasePlane()
    {
        if (isPurchased == 0)
        {
            // Load player's coin data
            CoinsData coinsData = SaveSystem.LoadCoins();
            coins = coinsData.coins;

            // Check if the player has enough coins to purchase the plane
            if (coins >= price)
            {
                // Deduct the price from the player's coins
                coins -= price;
                SaveSystem.SaveCoin(coins);

                // Update UI and set the plane as purchased
                priceText.text = "PURCHASED";
                isPurchased = 1;
                equipBtnText.text = "Select";

                // Save the purchase state
                PlayerPrefs.SetInt("Plane_" + planeID + "_isPurchased", isPurchased);
                PlayerPrefs.Save();

                Debug.Log(coinsData.coins);
                Debug.Log("Plane Purchase");
            }
            else
            {
                Debug.Log("Not enough coins for purchase");
            }
        }
    }

    // Handles the selection of the plane
    public void SelectPlane()
    {
        if (isPurchased == 1)
        {
            // Find all PlanePurchase objects in the scene
            PlanePurchase[] allPlanePurchase = FindObjectsOfType<PlanePurchase>();

            // Iterate through all planes
            foreach (PlanePurchase planePurchase in allPlanePurchase)
            {
                if (planePurchase == this)
                {
                    // Activate the selected state for the current plane
                    selectedBtnImg.gameObject.SetActive(true);
                    equipBtnText.text = "SELECTE";


                    // Save the selected plane
                    PlayerPrefs.SetInt("SelectedPlane", planeID);
                    PlayerPrefs.Save();
                }
                else
                {
                    // Deactivate the selected state for other planes
                    planePurchase.selectedBtnImg.gameObject.SetActive(false);
                   
                }
            }
        }
    }
}
