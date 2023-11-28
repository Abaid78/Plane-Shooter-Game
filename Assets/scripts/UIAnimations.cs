using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;

public class UIAnimations : MonoBehaviour
{
    // Synchronous FadeIn and FadeOut
    public void FadeIn(CanvasGroup canvasGroup, float animDuration)
    {
        canvasGroup.DOFade(1, animDuration).SetUpdate(true);
    }

    public void FadeOut(CanvasGroup canvasGroup, float animDuration)
    {
        canvasGroup.DOFade(0, animDuration).SetUpdate(true);
    }

    // Asynchronous FadeIn and FadeOut
    public async Task FadeInAsync(CanvasGroup canvasGroup, float animDuration)
    {
        try
        {
            await canvasGroup.DOFade(1, animDuration).SetUpdate(true).AsyncWaitForCompletion();
        }
        catch (System.Exception ex)
        {
            // Handle exceptions if needed
            Debug.LogError($"Error during FadeInAsync: {ex.Message}");
        }
    }

    public async Task FadeOutAsync(CanvasGroup canvasGroup, float animDuration)
    {
        try
        {
            await canvasGroup.DOFade(0, animDuration).SetUpdate(true).AsyncWaitForCompletion();
        }
        catch (System.Exception ex)
        {
            // Handle exceptions if needed
            Debug.LogError($"Error during FadeOutAsync: {ex.Message}");
        }
    }


public async Task FadeIn(CanvasGroup canvasGroup, float animDuration, float delayTime)
    {
        await canvasGroup.DOFade(1, animDuration).SetUpdate(true).SetDelay(delayTime).AsyncWaitForCompletion();
    }

    public async Task FadeOut(CanvasGroup canvasGroup, float animDuration, float delayTime)
    {
        await canvasGroup.DOFade(0, animDuration).SetUpdate(true).SetDelay(delayTime).AsyncWaitForCompletion();
    }

    public void Shake(RectTransform obj)
    {
        obj.DOShakePosition(0.5f, new Vector3(10, 10, 0), 10, 10, true)
          .SetLoops(2) // Loops indefinitely, restarting from the beginning each time
          .SetEase(Ease.InOutQuad);
    }
}