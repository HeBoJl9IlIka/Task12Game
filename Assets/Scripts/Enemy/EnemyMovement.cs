using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _path;
    [SerializeField] private SearchPlayer _searchPlayer;

    private int _currentPoint;
    private Transform[] _points;
    private bool _isDetected;

    public bool IsStunned { get; private set; } 

    public void Stop(float delay)
    {
        StartCoroutine(RemoveSpeed(delay));
    }

    private void Start()
    {
        _isDetected = false;

        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (_isDetected == false)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void OnEnable()
    {
        _searchPlayer.Detected += OnDetected;
        _searchPlayer.Lost += OnLost;
    }

    private void OnDisable()
    {
        _searchPlayer.Detected -= OnDetected;
        _searchPlayer.Lost -= OnLost;
    }

    private void OnDetected(Transform playerPosition)
    {
        _isDetected = true;
        _player = playerPosition;
    }

    private void OnLost()
    {
        _isDetected = false;
    }

    private void Patrol()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }

    private IEnumerator RemoveSpeed(float delay)
    {
        float temporary = _moveSpeed;
        _moveSpeed = 0;
        IsStunned = true;

        yield return new WaitForSeconds(delay);
        _moveSpeed = temporary;
        IsStunned = false;
    }
}
