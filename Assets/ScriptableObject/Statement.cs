using UnityEngine;

/// <summary>
/// Scriptable Object storing the configuration of a activity's statement
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Statement", order = 1)]
public class Statement : ScriptableObject
{
    #region private members

    [SerializeField] private int _numericValue;
    [SerializeField] private string _writtenValue;
    [SerializeField] private int _numberOfAnswers;
    [SerializeField] private int _retries;

    #endregion

    #region accessors

    public int NumericValue => _numericValue;
    public string WritternValue => _writtenValue;
    public int NumberOfAnswers => _numberOfAnswers;
    public int Retries => _retries;

    #endregion
}
