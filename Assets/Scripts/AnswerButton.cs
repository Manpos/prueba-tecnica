using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class AnswerButton : MonoBehaviour, IAnimatable
{
    [SerializeField] private TextMeshProUGUI _answerDisplay;
    [SerializeField] private Image _background;
    [SerializeField] private Button _button;

    public bool IsCorrect { get; private set; } = false;

    public void SetButtonSettings(int displayedAnswer, UnityAction<AnswerButton> onClickCallback, bool isCorrect)
    {
        _answerDisplay.text = displayedAnswer.ToString();
        _button.onClick.AddListener(()=>onClickCallback(this));
        IsCorrect = isCorrect;
    }

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }

    public void CorrectAnswer()
    {

    }

    public void IncorrectAnswer()
    {

    }
}
