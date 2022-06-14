using UnityEngine;

/// <summary>
/// Activity State where the statement is generated
/// </summary>
public class GenerateStatementState : ActivityState
{
    #region private members

    [SerializeField] private StatementConfigurator _statementConfigurator;
    [SerializeField] private ButtonsConfigurator _buttonsConfigurator;
    [SerializeField] private StatementsDictionary _statementsDictionary = null;

    private Statement _currentStatement = null;

    #endregion

    #region public methods

    public override void Enter()
    {
        SetNewStatement();
        ConfigurateStatement();
        _context.ChangeState(StateType.Preselection);
    }

    public override void Exit()
    {
        _currentStatement = null;
    }

    #endregion

    #region private methods

    /// <summary>
    /// Configures the Activity for the current Statement
    /// </summary>
    private void ConfigurateStatement()
    {
        _statementConfigurator.Generate(_currentStatement);
        _buttonsConfigurator.Generate(_currentStatement, ChangeToPostSelection);
        _context.ActivityCorrector.SetAnswersSettings(_buttonsConfigurator.AnswerButtons, _currentStatement.Retries);
    }

    /// <summary>
    /// Changes state to PostSelection, where the result is checked, used as buttons callback
    /// </summary>
    /// <param name="pressedButton"> Pressed button </param>
    private void ChangeToPostSelection(AnswerButton pressedButton)
    {
        _context.ActivityCorrector.RegisterAnswer(pressedButton);
        _context.ChangeState(StateType.Postselection);
    }

    /// <summary>
    /// Gets a new statement from the StatementsDictionary
    /// </summary>
    private void SetNewStatement()
    {
        _currentStatement = _statementsDictionary.GetRandomStatement();
    }

    #endregion
}
