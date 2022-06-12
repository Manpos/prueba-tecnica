using System.Collections;
using System.Collections.Generic;
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

    public void Hide()
    {
        StartCoroutine(Animations.FadeCanvas(_canvas, false, 2f));
    }

    public void Show()
    {
        StartCoroutine(Animations.FadeCanvas(_canvas, true, 2f));
    }

}
