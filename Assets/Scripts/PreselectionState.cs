public class PreselectionState : ActivityState
{
    public override void Enter()
    {
        _context.ConfigureStatement();
        _context.ChangeState(new SelectionState());
    }

    public override void Exit()
    {
        
    }

    private void GenerateNumber()
    {

    }

    private void AnimationIn()
    {

    }

    private void DisplayDelay()
    {

    }

    private void AnimationOut()
    {

    }
}
