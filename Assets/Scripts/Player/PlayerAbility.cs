using UnityEngine;
using UnityEngine.Events;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private int _currentCount;

    public bool IsStock => _currentCount > 0;
    public int CurrentCount => _currentCount;

    public UnityEvent Used;

    public void TryUse()
    {
        if (IsStock)
        {
            _currentCount--;
            Used?.Invoke();
        }
    }
}
