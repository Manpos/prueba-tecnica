using UnityEngine;

public class ActivityController : MonoBehaviour
{
    [SerializeField] private ActivityContext _context;
    [SerializeField] private ActivityStatesDictionary _statesDictionary;

    private void Start()
    {
        _statesDictionary.SetContextToAllStates(_context);
        _context.Initialize(_statesDictionary, StateType.GenerateStatement);
    }
}
