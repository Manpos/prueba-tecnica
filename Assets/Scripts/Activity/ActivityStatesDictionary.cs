using System.Collections.Generic;
using UnityEngine;

public partial class ActivityStatesDictionary : MonoBehaviour
{
    [SerializeField] private List<ActivityStateType> _activityStateTypes = new List<ActivityStateType>();

    public void SetContextToAllStates(ActivityContext context)
    {
        foreach (var stateType in _activityStateTypes)
        {
            stateType.ActivityState.SetContext(context);
        }
    }

    public ActivityState GetStateByType(StateType state)
    {
        ActivityStateType foundStateType = _activityStateTypes.Find(x => x.StateType == state);

        if (foundStateType != null)
        {
            return foundStateType.ActivityState;
        }
        else
        {
            return null;
        }
    }
}