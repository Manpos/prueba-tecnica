using UnityEngine;

/// <summary>
/// Manages the animations aplied to the UI elements
/// </summary>
public class AnimationManager : MonoBehaviour
{
    #region private members

    private readonly int _fadeIn = Animator.StringToHash("FadeIn");
    private readonly int _fadeOut = Animator.StringToHash("FadeOut");
    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _hidden = Animator.StringToHash("Hidden");

    [SerializeField] private Animator _animator;
    [SerializeField] private float _fadeDuration = 2f;

    #endregion

    #region public methods

    /// <summary>
    /// Sets the object to Idle animation
    /// </summary>
    public void Idle()
    {
        _animator.Play(_idle);
    }

    /// <summary>
    /// Sets the object to Hidden animation
    /// </summary>
    public void Hidden()
    {
        _animator.Play(_hidden);
    }

    /// <summary>
    /// Sets the object to FadeIn animation
    /// </summary>
    public void FadeIn()
    {
        _animator.speed = 1f / _fadeDuration;
        _animator.Play(_fadeIn);
    }

    /// <summary>
    /// Sets the object to FadeOut animation
    /// </summary>
    public void FadeOut()
    {
        _animator.speed = 1f / _fadeDuration;
        _animator.Play(_fadeOut);
    }

    /// <summary>
    /// Returns the fade animation duration
    /// </summary>
    /// <returns> Fade duration </returns>
    public float GetFadeDuration()
    {
        return _fadeDuration;
    }

    #endregion
}
