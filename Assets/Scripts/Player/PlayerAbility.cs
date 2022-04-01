using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private int _currentCount;

    public bool IsStock => _currentCount > 0;
    public UnityEvent Used;

    public void TryUse()
    {
        if (IsStock)
        {
            Used?.Invoke();
            _currentCount--;
        }
    }
}
