using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.Stop(_delay);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(_duration);
        gameObject.SetActive(false);
    }
}
