using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    private readonly int fadeIn = Animator.StringToHash("FadeIn");
    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int idle = Animator.StringToHash("Idle");
    private readonly int hidden = Animator.StringToHash("Hidden");

    [SerializeField] private Animator _animator;
    [SerializeField] private float _fadeDuration = 2f;

    public void Idle()
    {
        _animator.Play(idle);
    }

    public void Hidden()
    {
        _animator.Play(hidden);
    }

    public void FadeIn()
    {
        _animator.speed = 1f / _fadeDuration;
        _animator.Play(fadeIn);
    }

    public void FadeOut()
    {
        _animator.speed = 1f / _fadeDuration;
        _animator.Play(fadeOut);
    }

    public float GetFadeDuration()
    {
        return _fadeDuration;
    }
}
