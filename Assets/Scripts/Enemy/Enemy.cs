using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;

    private Quaternion _rotation = new Quaternion(0f, 0f, 0f, 0f);

    public Player Target => _target;

    private void Start()
    {
        FixBag();
    }

    private void FixBag()
    {
        transform.rotation = _rotation;
    }
}
