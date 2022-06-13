using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Statement", order = 1)]
public class Statement : ScriptableObject
{
    [SerializeField] private int _numericValue;
    [SerializeField] private string _writtenValue;
    [SerializeField] private int _numberOfAnswers;
    [SerializeField] private int _retries;

    public int NumericValue => _numericValue;
    public string WritternValue => _writtenValue;
    public int NumberOfAnswers => _numberOfAnswers;
    public int Retries => _retries;
}
