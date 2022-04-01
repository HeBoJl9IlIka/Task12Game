using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(_dynamicJoystick.Direction);
    }

    private void Move(Vector2 direction)
    {
        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector2 move = new Vector2(direction.x, direction.y);
        _rigidbody2D.MovePosition(_rigidbody2D.position + move * scaleMoveSpeed);
    }
}
