using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public async Task FadeIn(CanvasGroup canvasGroup, float animDuration)
    {
        await canvasGroup.DOFade(1, animDuration).SetUpdate(true).AsyncWaitForCompletion();
    }

    public async Task FadeOut(CanvasGroup canvasGroup, float animDuration)
    {
        await canvasGroup.DOFade(0, animDuration).SetUpdate(true).AsyncWaitForCompletion();
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