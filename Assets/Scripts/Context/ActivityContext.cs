using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivityContext : MonoBehaviour
{
    [SerializeField] private ActivityCorrector _activityCorrector;

    [SerializeField] private InputManager _inputManager;

    [SerializeField] private List<Statement> _statements = new List<Statement>();

    public InputManager Input => _inputManager;
    public ActivityCorrector ActivityCorrector => _activityCorrector;
    public Statement CurrentStatement { get; private set; }
    public ActivityStatesDictionary StatesDictionary { get; private set; }

    protected ActivityState _currentState = null;

    public void Initialize(ActivityStatesDictionary statesDictionary, StateType initialState)
    {
        StatesDictionary = statesDictionary;
        _currentState = StatesDictionary.GetStateByType(initialState);
        _currentState.Enter();
    }

    public Statement SetNewStatement()
    {
        return CurrentStatement = _statements[Random.Range(0, _statements.Count)];
    }

    public void ChangeState(StateType stateType)
    {
        _currentState.Exit();
        _currentState = StatesDictionary.GetStateByType(stateType);
        _currentState.Enter();
    }
}