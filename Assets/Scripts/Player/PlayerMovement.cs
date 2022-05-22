using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    private Rigidbody2D _rigidbody2D;

    public event UnityAction Moved;
    public event UnityAction Stopped;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(_dynamicJoystick.Direction);
    }

    private void Move(Vector2 directionJoystick)
    {
        if (directionJoystick == new Vector2(0, 0))
        {
            Stopped?.Invoke();
            return;
        }

        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector2 direction = new Vector2(directionJoystick.x, directionJoystick.y);
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * scaleMoveSpeed);
        Moved?.Invoke();
    }
}
