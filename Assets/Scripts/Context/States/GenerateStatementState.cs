using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStatementState : ActivityState
{
    [SerializeField] private StatementConfigurator _statementConfigurator;
    [SerializeField] private ButtonsConfigurator _buttonsConfigurator;
    [SerializeField] private StatementsDictionary _statementsDictionary = null;

    private Statement _currentStatement = null;

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

    private void ConfigurateStatement()
    {
        _statementConfigurator.Generate(_currentStatement);
        _buttonsConfigurator.Generate(_currentStatement, ChangeToPostSelection);
        _context.ActivityCorrector.SetAnswersSettings(_buttonsConfigurator.AnswerButtons, _currentStatement.Retries);
    }

    private void ChangeToPostSelection(AnswerButton pressedButton)
    {
        _context.ActivityCorrector.RegisterAnswer(pressedButton);
        _context.ChangeState(StateType.Postselection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Statement SetNewStatement()
    {
        return _currentStatement = _statementsDictionary.GetRandomStatement();
    }
}
