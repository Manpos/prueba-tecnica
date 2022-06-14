using UnityEngine;

/// <summary>
/// Activity state where the user input is being listened to
/// </summary>
public class SelectionState : ActivityState
{
    #region private members

    [SerializeField] private InputManager _inputManager;

    #endregion

    #region public methods

    public override void Enter()
    {
        _inputManager.EnableInput();
    }

    public override void Exit()
    {
        _inputManager.DisableInput();
    }

    #endregion
}
