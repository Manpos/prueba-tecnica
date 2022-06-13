using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class StatementConfigurator : MonoBehaviour
{
    [SerializeField] private StatementTitle _statementTitle;

    public StatementTitle StatementTitle => _statementTitle;

    public void Generate(Statement currentStatement)
    {
        _statementTitle.SetTitle(currentStatement.WritternValue);
    }
}
