using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private GameObject _buttonTakeItem;
    [SerializeField] private PlayerTaking _playerTake;
    [SerializeField] private TMP_Text _labelTitle;

    private void OnEnable()
    {
        _playerTake.Approached += OnApproached;
        _playerTake.Departed += OnDeparted;
    }

    private void OnDisable()
    {
        _playerTake.Approached -= OnApproached;
        _playerTake.Departed -= OnDeparted;
    }

    private void OnApproached(Item item)
    {
        _buttonTakeItem.SetActive(true);
        _labelTitle.text = "Взять " + item.Label;
    }

    private void OnDeparted()
    {
        _buttonTakeItem.SetActive(false);
    }
}
