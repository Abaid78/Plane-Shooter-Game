using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour
{
    public float animationDuration = 1.0f;
    public GameObject shopPanel;
    public CanvasGroup canvasGroup;
    public LeanTweenType leanTweenType;
    // Start is called before the first frame update
    void Start()
    {
      


    }
    public void am()
    {
        canvasGroup.alpha = 0f;

        // Use LeanTween to fade in the panel
        LeanTween.alphaCanvas(canvasGroup, 1.0f, animationDuration)
            .setEase(leanTweenType);
        shopPanel.gameObject.SetActive(true);
    }
    public void FadeOutAnimation(){
        
    }
}
