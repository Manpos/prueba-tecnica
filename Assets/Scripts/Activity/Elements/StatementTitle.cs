using TMPro;
using UnityEngine;

public class StatementTitle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private AnimationManager _animationManager;

    public AnimationManager AnimationManager => _animationManager;

    public void SetTitle(string title)
    {
        _title.text = title;
    }
}
