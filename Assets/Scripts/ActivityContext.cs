using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityContext : Context
{
    [SerializeField] private StatementConfigurator _statementConfigurator;
    [SerializeField] private ActivityCorrector _activityCorrector;
    [SerializeField] private int _numberOfAnswers = 3;

    public StatementConfigurator StatementConfigurator => _statementConfigurator;

    public void ConfigureStatement()
    {
        _statementConfigurator.Generate(_numberOfAnswers, _activityCorrector.CheckAnswer);
    }
}
