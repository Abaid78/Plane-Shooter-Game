using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ThemeManager : MonoBehaviour
{
   
    public TMP_Dropdown themeDropdown;
    public Color darkThemeColor;
    public Color lightThemeColor;
    public Image[] themeImages;
    public GameObject[] themePanels;

    private const string THEME_KEY = "SelectedTheme";
   
    private void Start()
    {
        // Load the selected theme from PlayerPrefs
        int savedTheme = PlayerPrefs.GetInt(THEME_KEY, 0);
        SetTheme(savedTheme);
    }

    // This method will be called when the selected dropdown option changes
    public void OnDropdownValueChanged()
    {
        // Get the currently selected option
        int selectedTheme = themeDropdown.value;

        // Save the selected theme to PlayerPrefs
        PlayerPrefs.SetInt(THEME_KEY, selectedTheme);

        // Set the theme
        SetTheme(selectedTheme);
    }

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
        themeDropdown.value = PlayerPrefs.GetInt(THEME_KEY);
        // Customize other elements for the light theme
        foreach (var image in themeImages)
        {
            image.color = Color.white;
        }

        foreach (var panel in themePanels)
        {
            // Set properties for light theme panels
            // For example: panel.GetComponent<Image>().color = Color.xxx;
        }
    }

    private void SetDarkTheme()
    {

        themeDropdown.value = PlayerPrefs.GetInt(THEME_KEY);
        foreach (var image in themeImages)
        {
            image.color = Color.gray;
        }

        foreach (var panel in themePanels)
        {
            // Set properties for dark theme panels
            // For example: panel.GetComponent<Image>().color = Color.xxx;
        }
    }
}
