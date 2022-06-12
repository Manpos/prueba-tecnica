using System.Collections;
using UnityEngine;

public abstract class State : IState
{
    protected Context _context = null;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public abstract void Enter();
    public abstract void Exit();
}