using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class to manage when the input reads are detected
/// </summary>
public class InputManager : MonoBehaviour
{
    #region private members

    [SerializeField] private EventSystem _eventSystem;

    #endregion

    #region public methods

    /// <summary>
    /// Enables the input reading
    /// </summary>
    public void EnableInput()
    {
        _eventSystem.enabled = true;
    }

    /// <summary>
    /// Disables the input reading
    /// </summary>
    public void DisableInput()
    {
        _eventSystem.enabled = false;
    }
    #endregion
}
