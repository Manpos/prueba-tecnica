using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatementsDictionary", order = 1)]
public class StatementsDictionary : ScriptableObject
{
    [SerializeField] private List<Statement> _statements;

    public Statement GetRandomStatement()
    {
        return _statements[Random.Range(0, _statements.Count)];
    }
}
