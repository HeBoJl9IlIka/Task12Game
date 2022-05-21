using UnityEngine;
using UnityEngine.Events;

public class AnimatorMainMenu : MonoBehaviour
{
    [SerializeField] private AnimationCapsule _animationCapsule;
    [SerializeField] private AnimationBaseLoading _animationBaseLoading;

    public UnityEvent AnimationCapsuleEnd;
    public UnityEvent AnimationBaseLoadingEnd;

    private void OnEnable()
    {
        _animationCapsule.Ended += OnAnimationCapsuleEnded;
        _animationBaseLoading.Ended += OnAnimationBaseLoadingEnded;
    }

    private void OnDisable()
    {
        _animationCapsule.Ended -= OnAnimationCapsuleEnded;
        _animationBaseLoading.Ended -= OnAnimationBaseLoadingEnded;
    }

    private void OnAnimationCapsuleEnded()
    {
        AnimationCapsuleEnd?.Invoke();
    }

    private void OnAnimationBaseLoadingEnded()
    {
        AnimationBaseLoadingEnd?.Invoke();
    }
}
