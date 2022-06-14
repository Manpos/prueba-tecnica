using UnityEngine;

/// <summary>
/// Base class for the States of the ActivityContext
/// </summary>
public abstract class ActivityState : MonoBehaviour
{
    #region protected members

    protected ActivityContext _context = null;

    #endregion

    #region public methods

    /// <summary>
    /// Sets the controller Context to the State
    /// </summary>
    /// <param name="context"> Controller Context </param>
    public void SetContext(ActivityContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method called when the State is entered
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// Method called when the State is exited
    /// </summary>
    public abstract void Exit();

    #endregion
}
