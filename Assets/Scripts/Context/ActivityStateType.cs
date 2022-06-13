using UnityEngine;

[System.Serializable]
public class ActivityStateType
{
    [SerializeField] private StateType _stateType;
    [SerializeField] private ActivityState _activityState;

    public StateType StateType => _stateType;
    public ActivityState ActivityState => _activityState;
}