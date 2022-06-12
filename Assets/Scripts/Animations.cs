using System.Collections;
using UnityEngine;

public static class Animations
{
    public static IEnumerator FadeCanvas(CanvasGroup canvas, bool fadeIn, float duration)
    {
        float fadeValue = fadeIn ? 1f : 0f;

        while (canvas.alpha != fadeValue)
        {
            Mathf.Lerp(canvas.alpha, fadeValue, duration);
        }

        yield return null;
    }
}
