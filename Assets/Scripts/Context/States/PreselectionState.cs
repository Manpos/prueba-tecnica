using System.Threading.Tasks;
using UnityEngine;

public class PreselectionState : ActivityState
{
    public override void Enter()
    {

        _context.ChangeState(StateType.Selection);
    }

    public override void Exit()
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
