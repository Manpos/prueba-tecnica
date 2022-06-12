using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityState : IState
{
    protected ActivityContext _context = null;

    public void SetContext(Context context)
    {
        _context = context as ActivityContext;
    }

    public abstract void Enter();
    public abstract void Exit();
}
