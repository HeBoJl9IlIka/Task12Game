using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private GameSaving _gameSaving;
    [SerializeField] private GameObject _buttonOpen;
    [SerializeField] private GameObject _imageItem;
    [SerializeField] private GameObject _block;
    [SerializeField] private LevelNumber _number;
    [SerializeField] private PlayerWarehouse.KeyCardColor _needKeyCardColor;

    public LevelNumber Number => _number;
    public bool IsOpen { get; private set; }

    public UnityEvent Opened;

    public enum LevelNumber
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }

    private void Awake()
    {
        IsOpen = _gameSaving.GetLevelData(this);

        if (IsOpen)
        {
            Opened?.Invoke();
        }
    }

    public void TryOpen()
    {
        IsOpen = _playerWarehouse.TryUseKeyCard(_needKeyCardColor);

        if (IsOpen)
        {
            Opened?.Invoke();
            _gameSaving.SetData();
        }
    }
}
