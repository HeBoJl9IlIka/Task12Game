using UnityEngine;
using TMPro;

public class CollectedItems : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TMP_Text _allItem;

    private Item[] _items;

    public void ShowItems()
    {
        foreach (var item in _items)
        {
            _allItem.text += item.Label + ". ";
        }
    }

    public void AddItems()
    {
        _items = _playerInventory.GetItems().ToArray();
    }
}
