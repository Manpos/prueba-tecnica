using System.Collections.Generic;
using UnityEngine;

public class ActivityContext : MonoBehaviour
{
    [SerializeField] private ActivityCorrector _activityCorrector;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private List<Statement> _statements = new List<Statement>();
    [SerializeField] private StatementTitle _statementTitle;
    [SerializeField] private StatementAnswers _statementAnswers;

    public InputManager Input => _inputManager;
    public ActivityCorrector ActivityCorrector => _activityCorrector;
    public StatementTitle StatementTitle => _statementTitle;
    public StatementAnswers StatementAnswers => _statementAnswers;
    public Statement CurrentStatement { get; private set; }
    public ActivityStatesDictionary StatesDictionary { get; private set; }

    private ActivityState _currentState = null;

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