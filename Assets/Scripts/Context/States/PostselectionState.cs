using System.Threading.Tasks;
using UnityEngine;

public class PostselectionState : ActivityState
{
    public override async void Enter()
    {
        await _context.ActivityCorrector.CheckAnswer();
        await ButtonsDisplay();
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

    private async Task ButtonsDisplay()
    {
        _context.StatementAnswers.AnimationManager.FadeOut();
        await Task.Delay((int)(_context.StatementAnswers.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementAnswers.AnimationManager.Hidden();
    }
}
