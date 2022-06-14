using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActivityCorrector : MonoBehaviour
{
    private const float CHECK_ANSWER_TIME = 2f;

    [SerializeField] private int _checksBeforeCorrection = 1;

    private int _correctAnswers = 0;
    private int _incorrectAnswers = 0;

    private int _checks = 0;
    private AnswerButton _userAnswer = null;

    private List<AnswerButton> _possibleAnswers = new List<AnswerButton>();

    public bool CompletedStatement { get; private set; } = false;

    public void RegisterAnswer(AnswerButton userAnswer)
    {
        _userAnswer = userAnswer;
    }

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

    public void SetAnswersSettings(List<AnswerButton> answerButtons, int checks)
    {
        _possibleAnswers = answerButtons;
        _checks = checks;
    }

    public void Reset()
    {
        _checks = 0;
        _userAnswer = null;
        CompletedStatement = false;
    }

    private async Task CorrectAnswer(AnswerButton pressedButton)
    {
        _correctAnswers++;
        pressedButton.SetBackgroundColor(Color.green);
        await Task.Delay((int)(CHECK_ANSWER_TIME * 1000));
        pressedButton.ResetBackgroundColor();
        CompletedStatement = true;
    }

    private async Task IncorrectAnswer(AnswerButton pressedButton)
    {
        _incorrectAnswers++;
        pressedButton.SetBackgroundColor(Color.red);
        await Task.Delay((int)(CHECK_ANSWER_TIME * 1000));
        pressedButton.ResetBackgroundColor();
    }

    private async Task Correction()
    {
        _incorrectAnswers++;
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
}
