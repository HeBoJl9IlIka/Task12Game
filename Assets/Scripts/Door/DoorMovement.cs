using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] private ButtonOpeningDoor _buttonOpeningDoor;
    [SerializeField] private Transform _door;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _speedMove;

    private Transform _defaultPosition;
    private Coroutine _currentCoroutine;

    public bool IsOpening { get; private set; }

    public UnityEvent OpenedDoor;
    public UnityEvent ClosedDoor;

    private void Start()
    {
        _defaultPosition = transform;
    }

    private void OnEnable()
    {
        _buttonOpeningDoor.ButtonPressed += OnButtonPressed;
        _buttonOpeningDoor.ButtonReleased += OnButtonReleased;
    }

    private void OnDisable()
    {
        _buttonOpeningDoor.ButtonPressed -= OnButtonPressed;
        _buttonOpeningDoor.ButtonReleased -= OnButtonReleased;
    }

    private void OnButtonPressed()
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(Open());
        OpenedDoor?.Invoke();
    }

    private void OnButtonReleased()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(Close());
        ClosedDoor?.Invoke();
    }

    private IEnumerator Open()
    {
        while (_door.position != _targetPosition.position)
        {
            _door.position = Vector3.MoveTowards(_door.position, _targetPosition.position, _speedMove * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Close()
    {
        while (_door.position != _defaultPosition.position)
        {
            _door.position = Vector3.MoveTowards(_door.position, _defaultPosition.position, _speedMove * Time.deltaTime);
            yield return null;
        }
    }
}
