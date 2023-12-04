using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime=1f;
    public Canvas crossfade;
    bool isTransitioning=false;
    private void Start()
    {
        crossfade.gameObject.SetActive(true);
    }
    public void LoadLevelWithPausedTime(int levelIndex)
    {
        if (!isTransitioning)
        {
            StartCoroutine(TransitionAndLoadLevelWithPausedTime(levelIndex));
        }
    }

    // Public method to load a level without transition animation and with normal time scale
    public void LoadLevelWithNormalTimeScale(int levelIndex)
    {
        StartCoroutine(LoadLevelWithoutTransitionWithNormalTimeScale(levelIndex));
    }

    // Coroutine for transitioning with animation and pause
    private IEnumerator TransitionAndLoadLevelWithPausedTime(int levelIndex)
    {
        isTransitioning = true;

        // Pause the game
        Time.timeScale = 0;

        // Trigger the transition animation
        transition.SetTrigger("Start");

        // Wait for the transitionTime while the game is paused
        yield return new WaitForSecondsRealtime(transitionTime);

        // Unpause the game before loading the next scene
        Time.timeScale = 1;

        // Load the next scene
        SceneManager.LoadScene(levelIndex);

        isTransitioning = false;
    }

    // Coroutine for loading a level without transition animation and with normal time scale
    private IEnumerator LoadLevelWithoutTransitionWithNormalTimeScale(int levelIndex)
    {
        // Trigger the transition animation
        transition.SetTrigger("Start");

        // Wait for the transitionTime
        yield return new WaitForSecondsRealtime(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }
}
