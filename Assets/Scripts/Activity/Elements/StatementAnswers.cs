using UnityEngine;

/// <summary>
/// Class to manage when is displayed the group of buttons
/// </summary>
public class StatementAnswers : MonoBehaviour
{
    [SerializeField] private AnimationManager _animationManager;

    public AnimationManager AnimationManager => _animationManager;
}
