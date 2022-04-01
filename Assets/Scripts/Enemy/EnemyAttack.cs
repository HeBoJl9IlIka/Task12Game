using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player) & _enemyMovement.IsStunned == false)
        {
            player.TakeDamage(_damage);
        }
    }
}
