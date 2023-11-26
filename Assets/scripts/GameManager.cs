using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        SceneManager.LoadScene(0);
    }
    public void ReloadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); ;
    }
}
