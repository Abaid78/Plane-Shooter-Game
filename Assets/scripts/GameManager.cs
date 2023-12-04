using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public LevelLoader levelLoader;
   
    public UIManager uiManager;
    public void ResumeGame()
    {
       
        uiManager.ShowOnResumeGame();
        
    }
    public void PauseGame()
    {
        uiManager.ShowOnPauseGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainManu()
    {
        levelLoader.LoadLevelWithPausedTime(0);
    }
    public void ReloadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelLoader.LoadLevelWithPausedTime(currentSceneIndex);
    }
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentSceneIndex + 1;
        PlayerPrefs.SetInt("LevelReached", nextLevel);
        levelLoader.LoadLevelWithPausedTime(nextLevel);
    }
}
