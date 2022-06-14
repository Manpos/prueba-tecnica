using UnityEngine;

/// <summary>
/// Configures the Statement displayed title
/// </summary>
public class StatementConfigurator : MonoBehaviour
{
    #region private members

    [SerializeField] private StatementTitle _statementTitle;

    #endregion

    #region public methods

    public void Generate(Statement currentStatement)
    {
        _statementTitle.SetTitle(currentStatement.WritternValue);
    }

    #endregion
}
