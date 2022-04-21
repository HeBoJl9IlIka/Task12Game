using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _path;

    private int _currentPoint;
    private Transform[] _points;
    private NavMeshAgent _agent;

    public bool IsNewTarget { get; private set; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Transform target = _points[_currentPoint];

        _agent.SetDestination(target.position);

        if (transform.position.x == target.position.x)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
