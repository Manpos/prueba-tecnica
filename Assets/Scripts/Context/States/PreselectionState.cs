using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Activity State where a set of animations is executed before letting the user introduce input
/// </summary>
public class PreselectionState : ActivityState
{
    #region private members

    [SerializeField] float _displayedTitleTime = 2f;

    #endregion

    #region public methods

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

    #endregion

    #region private methods

    /// <summary>
    /// Task displaying a set of animations to the Statement Title
    /// </summary>
    /// <returns> A task to be awaited to </returns>
    private async Task TitleDisplay()
    {
        _context.StatementTitle.AnimationManager.FadeIn();
        await Task.Delay((int)(_context.StatementTitle.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementTitle.AnimationManager.Idle();
        await Task.Delay((int)(_displayedTitleTime * 1000));

        _context.StatementTitle.AnimationManager.FadeOut();
        await Task.Delay((int)(_context.StatementTitle.AnimationManager.GetFadeDuration() * 1000));
    }

    /// <summary>
    /// Task displaying a set of animations to the Answer Buttons
    /// </summary>
    /// <returns> A task to be awaited to </returns>
    private async Task ButtonsDisplay()
    {
        _context.StatementAnswers.AnimationManager.FadeIn();
        await Task.Delay((int)(_context.StatementAnswers.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementAnswers.AnimationManager.Idle();
    }

    #endregion
}
