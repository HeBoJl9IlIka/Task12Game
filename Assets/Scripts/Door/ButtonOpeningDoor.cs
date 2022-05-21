using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonOpeningDoor : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    public UnityAction ButtonPressed;
    public UnityAction ButtonReleased;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            _spriteRenderer.color = _targetColor;
            ButtonPressed?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            _spriteRenderer.color = _defaultColor;
            ButtonReleased?.Invoke();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Rigidbody2D rigidbody))
    //    {
    //        _spriteRenderer.color = _targetColor;
    //        ButtonPressed?.Invoke();
    //    }
    //}
}
