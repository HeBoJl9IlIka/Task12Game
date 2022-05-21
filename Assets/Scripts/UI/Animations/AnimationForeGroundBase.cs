using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationForeGroundBase : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    
    private void Start()
    {
        _image.DOColor(_targetColor, _duration);
    }

    private void Update()
    {
        if (_image.color == _targetColor)
            gameObject.SetActive(false);
    }
}
