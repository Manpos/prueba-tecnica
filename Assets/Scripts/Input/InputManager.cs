using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;

    public void EnableInput()
    {
        _eventSystem.enabled = true;
    }

    public void DisableInput()
    {
        _eventSystem.enabled = false;
    }
}
