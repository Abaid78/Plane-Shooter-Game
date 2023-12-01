using System.Linq;
using UnityEngine;

public class SelectedSprite : MonoBehaviour
{
    public GameObject selectedImg; // Reference to the selected image GameObject
     SelectedSprite[] allSelectedSprites; // Array to store all instances of SelectedSprite
    public int thisScriptIndex; // Index of this script instance

    // Start is called before the first frame update
    private void Start()
    {
        // Find all SelectedSprite objects and order them by name
        allSelectedSprites = FindObjectsOfType<SelectedSprite>().OrderBy(x => x.name).ToArray();

        // Check if this script instance's index matches the stored PlayerPrefs level index
        if (thisScriptIndex == PlayerPrefs.GetInt("LevelIndex"))
        {
            selectedImg.SetActive(true); // Activate the selected image
        }
    }

    // Function to handle the button's selected sprite
    public void BtnSelectedSprite()
    {
        // Iterate through all SelectedSprite instances
        foreach (SelectedSprite selectSprite in allSelectedSprites)
        {
            if (selectSprite == this)
            {
                selectedImg.SetActive(true); // Activate the selected image for this instance
            }
            else
            {
                selectSprite.selectedImg.SetActive(false); // Deactivate the selected image for other instances
            }
        }
    }
}
