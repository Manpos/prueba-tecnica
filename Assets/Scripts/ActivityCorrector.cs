using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityCorrector : MonoBehaviour
{
    [SerializeField] private int checksBeforeCorrection = 1;

    private int correctAnswers = 0;
    private int incorrectAnswers = 0;

    private int checks = 0;

    public void CheckAnswer(AnswerButton answerButton)
    {
        if (answerButton.IsCorrect)
        {
            CorrectAnswer();
        }
        else if(!answerButton.IsCorrect && checks < checksBeforeCorrection)
        {
            IncorrectAnswer();
            checks++;
        }
        else
        {
            Correction();
        }
    }

    public void Reset()
    {
        checks = 0;
    }

    private void CorrectAnswer()
    {
        correctAnswers++;
        Debug.Log("Correct");
    }

    private void IncorrectAnswer()
    {
        incorrectAnswers++;
        Debug.Log("Incorrect");
    }

    private void Correction()
    {

    }
}
