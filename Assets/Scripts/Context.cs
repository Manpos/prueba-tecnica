using System.Collections;
using UnityEngine;

public abstract class Context : MonoBehaviour
{    
    private IState _currentState = null;

    public void Initialize(IState initialState)
    {
        _currentState = initialState;
        _currentState.SetContext(this);
        _currentState.Enter();
    }

    public void ChangeState(IState nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}