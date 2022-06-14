using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class containing a forming a collection of all available States of a Context
/// </summary>
public class ActivityStatesDictionary : MonoBehaviour
{
    #region private members

    [SerializeField] private List<ActivityStateType> _activityStateTypes = new List<ActivityStateType>();

    #endregion

    #region public methods

    /// <summary>
    /// Sets the Context to all the States in the List
    /// </summary>
    /// <param name="context"> Context to be set </param>
    public void SetContextToAllStates(ActivityContext context)
    {
        foreach (var stateType in _activityStateTypes)
        {
            stateType.ActivityState.SetContext(context);
        }
    }

    /// <summary>
    /// Consults if a StateType is listed in the list and returns its linked State
    /// </summary>
    /// <param name="state"> Type of the desired ActivityState </param>
    /// <returns> The ActivityState if found in the list, else returns null </returns>
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

    #endregion
}