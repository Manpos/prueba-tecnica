using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Statement", order = 1)]
public class Statement : ScriptableObject
{
    [SerializeField] private int _numericValue;
    [SerializeField] private string _writtenValue;

    public int NumericValue => _numericValue;
    public string WritternValue => _writtenValue;
}
