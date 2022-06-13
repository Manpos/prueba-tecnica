using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonsConfigurator : MonoBehaviour
{
    [SerializeField] private Transform _answersParent;
    [SerializeField] private AnswerButton _answerButtonPrefab;

    public List<AnswerButton> AnswerButtons { get; private set; } = new List<AnswerButton>();

    public void Generate(Statement currentStatement, UnityAction<AnswerButton> correctionCallback)
    {
        Reset();

        List<int> answers = AnswersList(currentStatement.NumericValue, currentStatement.NumberOfAnswers);

        for (int i = 0; i < answers.Count; i++)
        {
            AnswerButton newButton = Instantiate(_answerButtonPrefab, _answersParent);
            newButton.SetButtonSettings(answers[i], correctionCallback, answers[i] == currentStatement.NumericValue);
            AnswerButtons.Add(newButton);
        }
    }

    private void Reset()
    {
        for(int i = 0; i < AnswerButtons.Count; i++)
        {
            Destroy(AnswerButtons[i].gameObject);
        }
        AnswerButtons.Clear();
    }

    private List<int> AnswersList(int correctAnswer, int numberOfAnswers)
    {
        List<int> answers = new List<int>();
        int numberOffset;

        for (int i = 0; i < numberOfAnswers; i++)
        {
            int result;
            do
            {
                numberOffset = Random.Range(1, 10);
                int multiplier = Random.value < 0.5f ? -1 : 1;
                result = correctAnswer + numberOffset * multiplier;
            }
            while (answers.Contains(result) || result <= 0);

            answers.Add(result);
        }

        answers[Random.Range(0, answers.Count)] = correctAnswer;

        return answers;
    }

}
