using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackTransition : Transition
{
    [SerializeField] private float _distanceToTarget;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _distanceToTarget)
        {
            NeedTransit = true;
        }
    }
}
