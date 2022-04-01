using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerTaking : MonoBehaviour
{
    private Item _currentItem;
    private PlayerInventory _playerInventory;

    public UnityAction<Item> Approached;
    public UnityAction Departed;

    public void TakeItem()
    {
        _playerInventory.TryAddItem(_currentItem);
    }

    private void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out _currentItem))
        {
            Approached?.Invoke(_currentItem);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out _currentItem))
        {
            Departed?.Invoke();
        }
    }
}
