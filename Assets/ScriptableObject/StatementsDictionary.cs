using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object to store and query a list of Statements
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatementsDictionary", order = 1)]
public class StatementsDictionary : ScriptableObject
{
    #region private members

    [SerializeField] private List<Statement> _statements;

    #endregion

    #region public methods

    /// <summary>
    /// Returns a random statement contained in the list
    /// </summary>
    /// <returns> Random statement contained in the list </returns>
    public Statement GetRandomStatement()
    {
        return _statements[Random.Range(0, _statements.Count)];
    }

    #endregion
}
