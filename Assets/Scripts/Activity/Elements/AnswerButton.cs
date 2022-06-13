using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Threading.Tasks;

public class AnswerButton : MonoBehaviour
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

    public void SetBackgroundColor(Color color)
    {
        _background.color = color;
    }

    public void ResetBackgroundColor()
    {
        _background.color = Color.white;
    }
}
