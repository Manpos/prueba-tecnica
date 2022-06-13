using UnityEngine;

public class PostselectionState : ActivityState
{
    public override async void Enter()
    {
        await _context.ActivityCorrector.CheckAnswer();
        if (_context.ActivityCorrector.CompletedStatement)
        {
            _context.ChangeState(StateType.GenerateStatement);
        }
        else
        {
            _context.ChangeState(StateType.Preselection);
        }
    }

    public override void Exit()
    {
        if (_context.ActivityCorrector.CompletedStatement)
        {
            _context.ActivityCorrector.Reset();
        }
    }
}
