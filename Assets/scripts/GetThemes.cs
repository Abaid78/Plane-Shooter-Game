using UnityEngine;
using UnityEngine.UI;

public class GetThemes : MonoBehaviour
{
    public Image[] themeImages;
  
    private const string THEME_KEY = "SelectedTheme";

    private void Start()
    {
        // Load the selected theme from PlayerPrefs Getting from ThemeManager
        int savedTheme = PlayerPrefs.GetInt(THEME_KEY, 0);
        SetTheme(savedTheme);
    }

    // This method will be called when the selected dropdown option changes

    private void SetTheme(int themeIndex)
    {
        // Call the appropriate method based on the selected theme
        switch (themeIndex)
        {
            case 0:
                SetLightTheme();
                break;

            case 1:
                SetDarkTheme();

                break;
            // Add more cases for additional themes if needed
            default:
                SetLightTheme();
                break;
        }
    }

    private void SetLightTheme()
    {
        // Customize other elements for the light theme
        foreach (var image in themeImages)
        {
            image.color = Color.white;
        }
    }

    private void SetDarkTheme()
    {
        foreach (var image in themeImages)
        {
            image.color = Color.gray;
        }
    }
}