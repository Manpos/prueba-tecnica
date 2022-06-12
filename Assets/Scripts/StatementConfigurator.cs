using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatementConfigurator : MonoBehaviour
{
    [SerializeField] private List<Statement> _statements = new List<Statement>();
    [SerializeField] private StatementTitle _statementTitle;

    [SerializeField] private Transform _answersParent;
    [SerializeField] private AnswerButton _answerButtonPrefab;

    public void Generate(int numberOfAnswers, UnityAction<AnswerButton> correctionCallback)
    {
        Statement currentStatement = _statements[Random.Range(0, _statements.Count)];
        _statementTitle.SetTitle(currentStatement.WritternValue);
        int correctAnswer = currentStatement.NumericValue;

        int[] answers = AnswersList(correctAnswer, numberOfAnswers);

        for (int i = 0; i < answers.Length; i++)
        {
            AnswerButton newButton = Instantiate(_answerButtonPrefab, _answersParent);
            newButton.SetButtonSettings(answers[i], correctionCallback, answers[i] == correctAnswer);
        }

    }

    private int[] AnswersList(int correctAnswer, int numberOfAnswers)
    {
        int[] answers = new int[numberOfAnswers];
        int numberOffset;

        for (int i = 0; i < numberOfAnswers; i++)
        {
            numberOffset = Random.Range(1, 10);
            int multiplier = Random.value < 0.5f ? - 1 : 1;
            int result = correctAnswer + numberOffset * multiplier;

            if(result <= 0)
            {
                result = correctAnswer + numberOffset;
            }
            answers[i] = result;
        }

        answers[Random.Range(0, answers.Length)] = correctAnswer;

        return answers;
    }
}
