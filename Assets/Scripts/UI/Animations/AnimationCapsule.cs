using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnimationCapsule : MonoBehaviour
{
    [SerializeField] private Image _glassFront;
    [SerializeField] private Image _glassBack;
    [SerializeField] private Color _targetColorGlassFront;
    [SerializeField] private Color _targetColorGlassBack;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    public UnityEvent Opened;
    public UnityAction Ended;

    public void ChangeColorToTarget()
    {
        Opened?.Invoke();
        _glassFront.DOColor(_targetColorGlassFront, _duration).SetDelay(_delay);
        _glassBack.DOColor(_targetColorGlassBack, _duration).SetDelay(_delay);
        Invoke(nameof(AnnounceEnd), _duration + _delay);
    }

    private void AnnounceEnd()
    {
        Ended?.Invoke();
    }
}
