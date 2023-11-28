﻿using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        Time.timeScale = 1;
        endText.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
        gameCompletePanel.SetActive(false);


    }
    public async void ShowOnPauseGame(){
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        await uiAnimations.FadeIn(puaseMenuCG, animDurations);
        Time.timeScale = 0;
    }
  
    public async void ShowOnResumeGame(){
        await uiAnimations.FadeOut(puaseMenuCG, animDurations);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
       
    }
    public async void ShowOnGameOver(){
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        await uiAnimations.FadeIn(gameOverPanelCG, gameOverAnimDuration, delayTime);
        Time.timeScale = 0;
    }
    public async void ShowOnLevelComplete(){
        //yield return new WaitForSeconds(2f);
        endText.SetActive(true);
        //yield return new WaitForSeconds(3f);
        gameCompletePanel.SetActive(true);
        Time.timeScale=0f;
        await uiAnimations.FadeIn(gameCompletePanelCG, animDurations, delayTime);
    }
}