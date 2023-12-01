using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pauseMenu;

    public GameObject pauseButton;
    public GameObject gameOverPanel;
    public GameObject gameCompletePanel;
    public GameObject endText;
    public UIAnimations uiAnimations;

    [Header("CanvasGroups")]
    public CanvasGroup puaseMenuCG;

    public CanvasGroup gameOverPanelCG;
    public CanvasGroup gameCompletePanelCG;

    [Header("Animations Values")]
    public float animDurations = 0.5f;

    public float gameOverAnimDuration = 0.8f;
    public float delayTime = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        DOTween.SetTweensCapacity(1000, 50);
        endText.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
        gameCompletePanel.SetActive(false);
        SetAlpha();
    }

    public async void ShowOnPauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        await uiAnimations.FadeInAsync(puaseMenuCG, animDurations);
        Time.timeScale = 0;
    }

    public async void ShowOnResumeGame()
    {
        await uiAnimations.FadeOutAsync(puaseMenuCG, animDurations);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public async void ShowOnGameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        await uiAnimations.FadeInAsync(gameOverPanelCG, gameOverAnimDuration, delayTime);
        Time.timeScale = 0;
    }

    public IEnumerator ShowOnLevelComplete()
    {
        // Show endText after 2 seconds
        yield return new WaitForSeconds(2f);
        endText.SetActive(true);

        // Show gameCompletePanel after an additional 3 seconds
        yield return new WaitForSeconds(4f);

        // Pause the game (optional)
        Time.timeScale = 0;

        // Call LevelComplete method
        LevelComplete();
    }

    private async void LevelComplete()
    {
        // Activate the gameCompletePanel
        gameCompletePanel.SetActive(true);

        // Use async/await to wait for FadeInAsync to complete
        await uiAnimations.FadeInAsync(gameCompletePanelCG, animDurations, delayTime);

        // Kill all tweens
        DOTween.KillAll(); //kill because animations is going to update method and it create error
    }
    void SetAlpha()
    {
        gameCompletePanelCG.alpha = 0;
        gameOverPanelCG.alpha = 0;
        puaseMenuCG.alpha = 0;
    }
}