using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PreselectionState : ActivityState
{
    [SerializeField] float _displayedTitleTime = 2f;
    public override async void Enter()
    {
        _context.StatementTitle.AnimationManager.Hidden();
        _context.StatementAnswers.AnimationManager.Hidden();

        await TitleDisplay();
        await ButtonsDisplay();

        _context.ChangeState(StateType.Selection);
    }

    public override void Exit()
    {
        
    }

    private async Task TitleDisplay()
    {
        _context.StatementTitle.AnimationManager.FadeIn();
        await Task.Delay((int)(_context.StatementTitle.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementTitle.AnimationManager.Idle();
        await Task.Delay((int)(_displayedTitleTime * 1000));

        _context.StatementTitle.AnimationManager.FadeOut();
        await Task.Delay((int)(_context.StatementTitle.AnimationManager.GetFadeDuration() * 1000));
    }

    private async Task ButtonsDisplay()
    {
        _context.StatementAnswers.AnimationManager.FadeIn();
        await Task.Delay((int)(_context.StatementAnswers.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementAnswers.AnimationManager.Idle();
    }
}
