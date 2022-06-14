using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Manages the correction of the current activity
/// </summary>
public class ActivityCorrector : MonoBehaviour
{
    #region constants

    private const float CHECK_ANSWER_TIME = 2f;

    #endregion

    #region private members

    private int _correctAnswers = 0;
    private int _incorrectAnswers = 0;

    private int _checksBeforeCorrection = 1;
    private int _checks = 0;

    private AnswerButton _userAnswer = null;

    private List<AnswerButton> _possibleAnswers = new List<AnswerButton>();

    private ExecutionCounter _executionCounter;

    #endregion

    #region accessors

    public bool CompletedStatement { get; private set; } = false;

    #endregion

    #region monobehaviour

    private void Start()
    {
        _executionCounter = FindObjectOfType<ExecutionCounter>();
    }

    #endregion

    #region public methods

    /// <summary>
    /// Registers the button pressed by the user
    /// </summary>
    /// <param name="userAnswer"> Button pressed by the user </param>
    public void RegisterAnswer(AnswerButton userAnswer)
    {
        _userAnswer = userAnswer;
    }

    /// <summary>
    /// Creates a Task that displays asyncronously the result animation
    /// </summary>
    /// <returns> Task to await asyncronously </returns>
    public async Task CheckAnswer()
    {
        if (_userAnswer.IsCorrect)
        {
            await CorrectAnswer(_userAnswer);
        }
        else if(_checks < _checksBeforeCorrection)
        {
            await IncorrectAnswer(_userAnswer);
            _checks++;
        }
        else
        {
            await Correction();
        }
    }
    
    /// <summary>
    /// Registers the displayed answers and checks for the current statement
    /// </summary>
    /// <param name="answerButtons"> Possible answers </param>
    /// <param name="checksBeforeCorrection"> Chances of fail before displaying the correction </param>
    public void SetAnswersSettings(List<AnswerButton> answerButtons, int checksBeforeCorrection)
    {
        _possibleAnswers = answerButtons;
        _checksBeforeCorrection = checksBeforeCorrection;
    }

    /// <summary>
    /// Reverts the Corrector to its initial state
    /// </summary>
    public void Reset()
    {
        _checks = 0;
        _userAnswer = null;
        CompletedStatement = false;
    }

    #endregion

    #region private methods

    /// <summary>
    /// Displays a sequence showing that the pressed button is the correct button
    /// </summary>
    /// <param name="pressedButton"> The button pressed </param>
    /// <returns> An awaitable Task </returns>
    private async Task CorrectAnswer(AnswerButton pressedButton)
    {
        _correctAnswers++;
        _executionCounter.UpdateCorrect(_correctAnswers);
        pressedButton.SetBackgroundColor(Color.green);
        await Task.Delay((int)(CHECK_ANSWER_TIME * 1000));
        pressedButton.ResetBackgroundColor();
        CompletedStatement = true;
    }

    /// <summary>
    /// Displays a sequence showing that the pressed button is the incorrect button
    /// </summary>
    /// <param name="pressedButton"> The button pressed </param>
    /// <returns> An awaitable Task </returns>
    private async Task IncorrectAnswer(AnswerButton pressedButton)
    {
        _incorrectAnswers++;
        _executionCounter.UpdateIncorrect(_incorrectAnswers);
        pressedButton.SetBackgroundColor(Color.red);
        await Task.Delay((int)(CHECK_ANSWER_TIME * 1000));
        pressedButton.ResetBackgroundColor();
    }

    /// <summary>
    /// Displays a sequence showing the correct button in green and the others in red
    /// </summary>
    /// <returns> An awaitable Task </returns>
    private async Task Correction()
    {
        _incorrectAnswers++;
        _executionCounter.UpdateIncorrect(_incorrectAnswers);
        foreach (var item in _possibleAnswers)
        {
            if (item.IsCorrect)
            {
                item.SetBackgroundColor(Color.green);
            }
            else
            {
                item.SetBackgroundColor(Color.red);
            }
        }

        await Task.Delay((int)(CHECK_ANSWER_TIME * 1000));

        foreach (var item in _possibleAnswers)
        {
            item.ResetBackgroundColor();
        }

        CompletedStatement = true;
    }

    #endregion
}
