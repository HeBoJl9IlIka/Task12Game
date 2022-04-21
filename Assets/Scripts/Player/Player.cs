using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public bool IsDead => _health <= 0;

    public UnityEvent Died;
    public UnityEvent TookDamage;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        TookDamage?.Invoke();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Died?.Invoke();
        }
    }
}
