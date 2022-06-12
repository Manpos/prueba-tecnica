using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityController : MonoBehaviour
{
    [SerializeField] private ActivityContext _context;

    private void Start()
    {
        _context.Initialize(new PreselectionState());
    }
}
