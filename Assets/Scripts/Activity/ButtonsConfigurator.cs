using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Configures the buttons availabe for the user to respond
/// </summary>
public class ButtonsConfigurator : MonoBehaviour
{
    #region private members

    [SerializeField] private Transform _answersParent;
    [SerializeField] private AnswerButton _answerButtonPrefab;

    #endregion

    #region accessors

    public List<AnswerButton> AnswerButtons { get; private set; } = new List<AnswerButton>();

    #endregion

    #region public methods

    /// <summary>
    /// Generates the buttons to read the user input
    /// </summary>
    /// <param name="currentStatement"> Current Statement parameters to configure the buttons </param>
    /// <param name="correctionCallback"> Callback executed when the buttons are pressed </param>
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

    #endregion

    #region private methods

    /// <summary>
    /// Removes all previously instanced buttons
    /// </summary>
    private void Reset()
    {
        for(int i = 0; i < AnswerButtons.Count; i++)
        {
            Destroy(AnswerButtons[i].gameObject);
        }
        AnswerButtons.Clear();
    }

    /// <summary>
    /// Generates a list of posible answers including the correct one
    /// </summary>
    /// <param name="correctAnswer"> Correct answer </param>
    /// <param name="numberOfAnswers"> Number of possible answers to be diplayed </param>
    /// <returns> Returns a list of possible answers including the correct one </returns>
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

    #endregion
}
