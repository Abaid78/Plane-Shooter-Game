using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] selectionButtons;
    public Slider[] levelProgressSliders;
    public Text[] levelProgressSlidersText;

    private void OnEnable()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);//use in level1..
        for (int i = 0; i < selectionButtons.Length; i++)
        {
            levelProgressSliders[i].value = PlayerPrefs.GetFloat("Level_" + (i + 1) + "_Progress");
            levelProgressSlidersText[i].text = levelProgressSliders[i].value.ToString() + "%";
            Text unLockText = selectionButtons[i].GetComponentInChildren<Text>();
            if (i + 1 > levelReached)
            {
                selectionButtons[i].interactable = false;
            }
            else
            {
                unLockText.text = "UNLOCK";
            }
        }
    }

    public void LevelSelect(int index)
    {
        PlayerPrefs.SetInt("LevelIndex", index);
        PlayerPrefs.Save();
        Debug.Log("button " + index);
    }

    public void StartGame()
    {
        int index = PlayerPrefs.GetInt("LevelIndex", 1);
        SceneManager.LoadScene(index);
    }
}