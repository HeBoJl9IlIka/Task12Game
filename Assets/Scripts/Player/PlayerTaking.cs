using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerTaking : MonoBehaviour
{
    private Item _currentItem;
    private PlayerInventory _playerInventory;

    public UnityAction<Item> Approached;
    public UnityAction Departed;
    public UnityAction Took;

    public void TryTakeItem()
    {
        if (_playerInventory.TryAddItem(_currentItem))
            Took?.Invoke();
    }

    private void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out _currentItem))
            Approached?.Invoke(_currentItem);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out _currentItem))
            Departed?.Invoke();
    }
}
