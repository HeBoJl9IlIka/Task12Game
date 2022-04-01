using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _maxCountItem;
    [SerializeField] private List<Item> _items;

    public bool IsFull => _items.Count >= _maxCountItem;

    public void TryAddItem(Item item)
    {
        if (IsFull == false)
        {
            _items.Add(item);
            item.Disable();
        }
    }

    public string ShowItems()
    {
        string allItem = "Нет предметов";
        if (_items.Count > 0)
        {
            allItem = "";
            foreach (var item in _items)
            {
                allItem += item.Label + ". ";
            }
        }

        return allItem;
    }

    public List<Item> GetItems()
    {
        return _items;
    }

    private void Awake()
    {
        _items = new List<Item>();
    }
}
