using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationWindow : MonoBehaviour
{
    [SerializeField] private Image _shadow;
    [SerializeField] private Image _window;
    [SerializeField] private Color _shadowTargetColor;
    [SerializeField] private Color _windowTargetColor;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    public void ChangeColorToTarget()
    {
        _shadow.DOColor(_shadowTargetColor, _duration).SetDelay(_delay);
        _window.DOColor(_windowTargetColor, _duration).SetDelay(_delay);
    }
}
