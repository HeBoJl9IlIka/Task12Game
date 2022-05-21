using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationBlueLight : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    public void ChangeColorToTarget()
    {
        _image.DOColor(_targetColor, _duration).SetDelay(_delay);
    }
}
