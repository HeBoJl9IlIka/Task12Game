using UnityEngine;

public class TargetLostTransition : Transition
{
    [SerializeField] private float _distanceToTarget;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _distanceToTarget)
        {
            NeedTransit = true;
        }
    }
}
