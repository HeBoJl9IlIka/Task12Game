using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _delay;

    private Transform _defaultPosition;

    public bool IsOpening { get; private set; }

    public UnityEvent OpenedDoor;
    public UnityEvent ClosedDoor;

    private void Start()
    {
        _defaultPosition = transform;
    }

    private void Update()
    {
        if (IsOpening)
        {
            _door.position = Vector3.MoveTowards(_door.position, _targetPosition.position, _delay * Time.deltaTime);
        }
        else
        {
            _door.position = Vector3.MoveTowards(_door.position, _defaultPosition.position, _delay * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            IsOpening = true;
            OpenedDoor?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            IsOpening = false;
            ClosedDoor?.Invoke();
        }
    }
}
