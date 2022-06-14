using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// Interactable button used by the user to answer the Statement
/// </summary>
public class AnswerButton : MonoBehaviour
{
    #region private members

    [SerializeField] private TextMeshProUGUI _answerDisplay;
    [SerializeField] private Image _background;
    [SerializeField] private Button _button;

    #endregion

    #region accessors

    public bool IsCorrect { get; private set; } = false;

    #endregion

    #region public methods

    /// <summary>
    /// Sets the configuration for the button
    /// </summary>
    /// <param name="displayedAnswer"></param>
    /// <param name="onClickCallback"></param>
    /// <param name="isCorrect"></param>
    public void SetButtonSettings(int displayedAnswer, UnityAction<AnswerButton> onClickCallback, bool isCorrect)
    {
        _answerDisplay.text = displayedAnswer.ToString();
        _button.onClick.AddListener(()=>onClickCallback(this));
        IsCorrect = isCorrect;
    }

    /// <summary>
    /// Sets the button's background color
    /// </summary>
    /// <param name="color"></param>
    public void SetBackgroundColor(Color color)
    {
        _background.color = color;
    }

    /// <summary>
    /// Resets the background color to white
    /// </summary>
    public void ResetBackgroundColor()
    {
        _background.color = Color.white;
    }

    #endregion
}
