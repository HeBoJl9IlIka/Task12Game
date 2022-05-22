using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _maxCountItem;
    [SerializeField] private List<Item> _items;

    public bool IsFull => _items.Count >= _maxCountItem;
    public int MaxCount => _maxCountItem;
    public int CurrentItemCount => _items.Count;

    private void Start()
    {
        _items = new List<Item>();
    }

    public bool TryAddItem(Item item)
    {
        if (IsFull == false)
        {
            _items.Add(item);
            item.Disable();
            return true;
        }
        return false;
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

    public Item[] GetItems()
    {
        return _items.ToArray();
    }
}
