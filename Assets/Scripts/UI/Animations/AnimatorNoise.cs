using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class AnimatorNoise : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    private Image _image;
    private Animator _animator;

    private void Start()
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        _image.color = _defaultColor;
    }

    public void Show()
    {
        _animator.enabled = true;
        _image.color = _targetColor;
        Invoke(nameof(Hide), _delay);
        Invoke(nameof(DisableImage), _delay + _duration);
    }

    private void Hide()
    {
        _image.DOColor(_defaultColor, _duration);
    }

    private void DisableImage()
    {
        _animator.enabled = false;
    }
}
