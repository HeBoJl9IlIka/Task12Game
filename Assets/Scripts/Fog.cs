using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fog : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _dimmingSpeed;

    private Tilemap _fog;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _fog = GetComponent<Tilemap>();
        _fog.color = _defaultColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(HideFogs());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(ShowFogs());
        }
    }

    private IEnumerator HideFogs()
    {
        while (_fog.color != _targetColor)
        {
            _fog.color = Color.Lerp(_fog.color, _targetColor, _dimmingSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator ShowFogs()
    {
        while (_fog.color != _defaultColor)
        {
            _fog.color = Color.Lerp(_fog.color, _defaultColor, _dimmingSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}
