using TMPro;
using UnityEngine;

/// <summary>
/// Debug tool to count the Success and Fails on a single execution
/// </summary>
public class ExecutionCounter : MonoBehaviour
{
    #region constants

    private const string CORRECT_ANSWERS = "Aciertos: ";
    private const string INCORRECT_ANSWERS = "Fallos: ";

    #endregion

    #region private members

    [SerializeField] private TextMeshProUGUI _correctAnswersDisplay;
    [SerializeField] private TextMeshProUGUI _incorrectAnswersDisplay;

    #endregion

    #region monobehaviour

    private void Start()
    {
        UpdateCorrect(0);
        UpdateIncorrect(0);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Updates the "correct" text
    /// </summary>
    /// <param name="value"> New displayed value </param>
    public void UpdateCorrect(int value)
    {
        _correctAnswersDisplay.text = CORRECT_ANSWERS + value;
    }

    /// <summary>
    /// Updates the "incorrect" text
    /// </summary>
    /// <param name="value"> New displayed value </param>
    public void UpdateIncorrect(int value)
    {
        _incorrectAnswersDisplay.text = INCORRECT_ANSWERS + value;
    }

    #endregion
}
