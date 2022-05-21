using UnityEngine;

public class TargetDetectedTransition : Transition
{
    [SerializeField] private float _distanceToTarget;
    [SerializeField] private float _impactDistance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _distanceToTarget  & Vector2.Distance(transform.position, Target.transform.position) > _impactDistance)
        {
            NeedTransit = true;
        }
    }
}
