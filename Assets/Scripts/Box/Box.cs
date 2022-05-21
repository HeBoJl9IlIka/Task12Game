using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Box : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _minSpeed = 0.5f;

    public UnityAction Moved;
    public UnityAction Stopped;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.magnitude == 0)
            return;

        if (_rigidbody2D.velocity.magnitude > 0 & _rigidbody2D.velocity.magnitude < _minSpeed)
        {
            Stopped?.Invoke();
        }
        else if (_rigidbody2D.velocity.magnitude > _minSpeed)
        {
            Moved?.Invoke();
        }
    }
}
