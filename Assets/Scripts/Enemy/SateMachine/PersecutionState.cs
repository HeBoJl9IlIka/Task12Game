using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class PersecutionState : State
{
    [SerializeField] private float _moveSpeed;

    private NavMeshAgent _agent;
    private float _defaultSpeed;

    public UnityEvent Haunts;
    public UnityEvent Missed;

    private void Start()
    {
        _defaultSpeed = _moveSpeed;

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _moveSpeed;
    }

    private void Update()
    {
        _agent.SetDestination(Target.transform.position);
    }

    private void OnEnable()
    {
        Haunts?.Invoke();
    }

    private void OnDisable()
    {
        Missed?.Invoke();
    }

    public void Stun(float delay)
    {
        StopMovement();
        Invoke(nameof(RestoreMovement), delay);
    }

    private void StopMovement()
    {
        _agent.speed = 0;
    }

    private void RestoreMovement()
    {
        _agent.speed = _defaultSpeed;
    }
}
