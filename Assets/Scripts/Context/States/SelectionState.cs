using UnityEngine;

public class SelectionState : ActivityState
{
    public override void Enter()
    {
        _context.Input.EnableInput();
    }

    public override void Exit()
    {
        _context.Input.DisableInput();
    }
}
