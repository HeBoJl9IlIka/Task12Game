using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private float _enemyStunTime;
    [SerializeField] private float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PersecutionState enemy))
        {
            enemy.Stun(_enemyStunTime);
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(Disable), _duration);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
