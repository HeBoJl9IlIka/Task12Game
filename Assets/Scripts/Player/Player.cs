using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _tookDamage;

    public UnityEvent Died;
    public UnityAction<int> TookDamage;
    
    public bool IsDead => _health <= 0;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _tookDamage?.Invoke();
        TookDamage?.Invoke(_health);
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
