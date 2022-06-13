using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityState : MonoBehaviour
{
    protected ActivityContext _context = null;

    public void SetContext(ActivityContext context)
    {
        _context = context;
    }

    public abstract void Enter();
    public abstract void Exit();
}
