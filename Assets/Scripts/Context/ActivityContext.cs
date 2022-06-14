using UnityEngine;

/// <summary>
/// Class to manage the State and relevant data regarding the current activity
/// </summary>
public class ActivityContext : MonoBehaviour
{
    #region private members

    [SerializeField] private ActivityCorrector _activityCorrector;
    [SerializeField] private StatementTitle _statementTitle;
    [SerializeField] private StatementAnswers _statementAnswers;

    private ActivityState _currentState = null;
    private ActivityStatesDictionary _statesDictionary;

    #endregion

    #region accessors

    public ActivityCorrector ActivityCorrector => _activityCorrector;
    public StatementTitle StatementTitle => _statementTitle;
    public StatementAnswers StatementAnswers => _statementAnswers;

    #endregion

    #region public methods

    /// <summary>
    /// Initializes the context
    /// </summary>
    /// <param name="statesDictionary"> Reference to the States Dictionary </param>
    /// <param name="initialState"> First state to Enter </param>
    public void Initialize(ActivityStatesDictionary statesDictionary, StateType initialState)
    {
        _statesDictionary = statesDictionary;
        _currentState = _statesDictionary.GetStateByType(initialState);
        _currentState.Enter();
    }

    /// <summary>
    /// Method to change between states
    /// </summary>
    /// <param name="stateType"> State to change to </param>
    public void ChangeState(StateType stateType)
    {
        _currentState.Exit();
        _currentState = _statesDictionary.GetStateByType(stateType);
        _currentState.Enter();
    }

    #endregion
}