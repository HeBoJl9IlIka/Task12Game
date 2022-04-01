using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LoadingBaseScene : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;

    private Item[] _items;

    public void LoadBaseScene()
    {
        AddItems();
        Base.Load(_items);
    }

    private void AddItems()
    {
        _items = _playerInventory.GetItems().ToArray();
    }
}
