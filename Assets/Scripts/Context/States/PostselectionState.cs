using System.Threading.Tasks;

/// <summary>
/// Activity State where the pressed button gets corrected
/// </summary>
public class PostselectionState : ActivityState
{
    #region public methods

    public override async void Enter()
    {
        await _context.ActivityCorrector.CheckAnswer();
        await ButtonsHide();
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

    #endregion

    #region private methods

    /// <summary>
    /// Hides the Answer Buttons
    /// </summary>
    /// <returns> A Task to be awaited to </returns>
    private async Task ButtonsHide()
    {
        _context.StatementAnswers.AnimationManager.FadeOut();
        await Task.Delay((int)(_context.StatementAnswers.AnimationManager.GetFadeDuration() * 1000));

        _context.StatementAnswers.AnimationManager.Hidden();
    }

    #endregion
}
