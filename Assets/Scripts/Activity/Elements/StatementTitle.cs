using TMPro;
using UnityEngine;

/// <summary>
/// Manages the displayed Title on each Statement
/// </summary>
public class StatementTitle : MonoBehaviour
{
    #region private members

    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private AnimationManager _animationManager;

    #endregion

    #region accessors

    public AnimationManager AnimationManager => _animationManager;

    #endregion

    #region public methods

    /// <summary>
    /// Sets the title of the Statement
    /// </summary>
    /// <param name="title"> Title to be set </param>
    public void SetTitle(string title)
    {
        _title.text = title;
    }

    #endregion
}
