using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonOpeningDoor : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    public void ChangeToTargetColor()
    {
        _spriteRenderer.color = _targetColor;
    }

    public void ChangeToDefaultColor()
    {
        _spriteRenderer.color = _defaultColor;
    }
}
