using UnityEngine;

public class StatementConfigurator : MonoBehaviour
{
    [SerializeField] private StatementTitle _statementTitle;

    public StatementTitle StatementTitle => _statementTitle;

    public void Generate(Statement currentStatement)
    {
        _statementTitle.SetTitle(currentStatement.WritternValue);
    }
}
