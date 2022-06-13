using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStatementState : ActivityState
{
    [SerializeField] private StatementConfigurator _statementConfigurator;
    [SerializeField] private ButtonsConfigurator _buttonsConfigurator;

    public override void Enter()
    {
        _context.SetNewStatement();
        ConfigurateStatement();
        _context.ChangeState(StateType.Preselection);
    }

    public override void Exit()
    {
        
    }

    private void ConfigurateStatement()
    {
        _statementConfigurator.Generate(_context.CurrentStatement);
        _buttonsConfigurator.Generate(_context.CurrentStatement, ChangeToPostSelection);
        _context.ActivityCorrector.SetButtons(_buttonsConfigurator.AnswerButtons);
    }

    private void ChangeToPostSelection(AnswerButton pressedButton)
    {
        _context.ActivityCorrector.RegisterAnswer(pressedButton);
        _context.ChangeState(StateType.Postselection);
    }
}
