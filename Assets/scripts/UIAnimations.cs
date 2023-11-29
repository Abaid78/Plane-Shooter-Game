using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
 
    // Synchronous FadeIn and FadeOut
    public void FadeIn(CanvasGroup canvasGroup, float animDuration)
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1, animDuration).SetUpdate(true);
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }

    public void FadeOut(CanvasGroup canvasGroup, float animDuration)
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0, animDuration).SetUpdate(true);
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }

    // Asynchronous FadeIn and FadeOut
    public async Task FadeInAsync(CanvasGroup canvasGroup, float animDuration)
    {
        if (canvasGroup != null)
        {

            await canvasGroup.DOFade(1, animDuration).SetUpdate(true).AsyncWaitForCompletion();
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }

    public async Task FadeOutAsync(CanvasGroup canvasGroup, float animDuration)
    {
        if (canvasGroup != null)
        {
          
                await canvasGroup.DOFade(0, animDuration).SetUpdate(true).AsyncWaitForCompletion();
           
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }  public async Task FadeInAsync(CanvasGroup canvasGroup, float animDuration,float delayTime)
    {
        if (canvasGroup != null)
        {

            await canvasGroup.DOFade(1, animDuration).SetUpdate(true).SetDelay(delayTime).AsyncWaitForCompletion();
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }

    public async Task FadeOutAsync(CanvasGroup canvasGroup, float animDuration,float delayTime)
    {
        if (canvasGroup != null)
        {
          
                await canvasGroup.DOFade(0, animDuration).SetUpdate(true).SetDelay(delayTime).AsyncWaitForCompletion();
           
        }
        else
        {
            // Handle the case where the CanvasGroup is null
            Debug.LogWarning("CanvasGroup is null. The tween won't be performed.");
        }
    }

   

    public void Shake(RectTransform obj)
    {
        obj.DOShakePosition(0.5f, new Vector3(10, 10, 0), 10, 10, true)
          .SetLoops(2) // Loops indefinitely, restarting from the beginning each time
          .SetEase(Ease.InOutQuad);
    }
}