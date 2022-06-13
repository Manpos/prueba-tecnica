using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Animations
{
    public async Task FadeCanvas(CanvasGroup canvas, bool fadeIn, float duration)
    {
        float fadeValue = fadeIn ? 1f : 0f;
        float time = 0;

        while (canvas.alpha != fadeValue)
        {
            canvas.alpha = Mathf.Lerp(canvas.alpha, fadeValue, time);
            time += Time.deltaTime / duration;
        }

        await Task.Delay((int)(duration * 1000));
    }
}
