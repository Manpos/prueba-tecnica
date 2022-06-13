using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private readonly int fadeIn = Animator.StringToHash("FadeIn");
    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int idle = Animator.StringToHash("Idle");
    private readonly int hidden = Animator.StringToHash("Hidden");

    [SerializeField] private Animator _animator;

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
        _animator.Play(fadeIn);
    }

    public void FadeOut()
    {
        _animator.Play(fadeOut);
    }

    public float GetCurrentClipLength()
    {
        return _animator.GetCurrentAnimatorClipInfo(0).Length;
    }
}
