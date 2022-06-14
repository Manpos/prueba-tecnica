
/// <summary>
/// Activity state where the user input is being listened to
/// </summary>
public class SelectionState : ActivityState
{
    #region public methods

    public override void Enter()
    {
        _context.Input.EnableInput();
    }

    public override void Exit()
    {
        _context.Input.DisableInput();
    }

    #endregion
}
