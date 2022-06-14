using UnityEngine;

/// <summary>
/// Starts the activity
/// </summary>
public class ActivityStarter : MonoBehaviour
{
    #region private members

    [SerializeField] private ActivityContext _context;
    [SerializeField] private ActivityStatesDictionary _statesDictionary;

    #endregion

    #region monobehaviour

    /// <summary>
    /// Configurates the States in the dictionary with the current Context and initializes the context
    /// </summary>
    private void Start()
    {
        _statesDictionary.SetContextToAllStates(_context);
        _context.Initialize(_statesDictionary, StateType.GenerateStatement);
    }

    #endregion
}
