using UnityEngine;

/// <summary>
/// Class linking a StateType to an Activity State
/// </summary>
[System.Serializable]
public class ActivityStateType
{
    #region private members

    [SerializeField] private StateType _stateType;
    [SerializeField] private ActivityState _activityState;

    #endregion

    #region accessors
    public StateType StateType => _stateType;
    public ActivityState ActivityState => _activityState;
    #endregion
}