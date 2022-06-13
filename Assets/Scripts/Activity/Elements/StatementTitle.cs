using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class StatementTitle : MonoBehaviour, IAnimatable
{
    [SerializeField] private CanvasGroup _canvas;
    [SerializeField] private TextMeshProUGUI _title;

    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public async Task Hide()
    {
        _canvas.alpha = 1;
        await new Animations().FadeCanvas(_canvas, false, 2f);
    }

    public async Task Show()
    {
        _canvas.alpha = 0;
        await new Animations().FadeCanvas(_canvas, true, 2f);
    }

}
