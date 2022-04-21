using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PersecutionState enemy))
        {
            enemy.Stun(_delay);
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
