using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private GameObject _buttonTakeItem;
    [SerializeField] private PlayerTaking _playerTaking;
    [SerializeField] private PlayerAbility _playerAbility;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TMP_Text _labelTitle;
    [SerializeField] private TMP_Text _itemCounter;
    [SerializeField] private TMP_Text _abilityCounter;
    
    private void OnEnable()
    {
        _playerTaking.Approached += OnApproached;
        _playerTaking.Departed += OnDeparted;
        _playerTaking.Took += OnTook;
    }

    private void OnDisable()
    {
        _playerTaking.Approached -= OnApproached;
        _playerTaking.Departed -= OnDeparted;
        _playerTaking.Took -= OnTook;
    }

    public void UpdateAbilityCount()
    {
        _abilityCounter.text = "x" + _playerAbility.CurrentCount.ToString();
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

    private void OnTook()
    {
        _itemCounter.text = _playerInventory.CurrentItemCount + "/" + _playerInventory.MaxCount.ToString();
    }
}
