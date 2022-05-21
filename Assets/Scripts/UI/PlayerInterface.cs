using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private GameObject _buttonTakeItem;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerTaking _playerTaking;
    [SerializeField] private PlayerAbility _playerAbility;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TMP_Text _labelTitle;
    [SerializeField] private TMP_Text _abilityCounter;
    [SerializeField] private Slider _healthBar; 

    private void Start()
    {
        UpdateAbilityCount();
    }

    private void OnEnable()
    {
        _playerTaking.Approached += OnApproached;
        _playerTaking.Departed += OnDeparted;
        _player.TookDamage += OnTookDamage;
    }

    private void OnDisable()
    {
        _playerTaking.Approached -= OnApproached;
        _playerTaking.Departed -= OnDeparted;
        _player.TookDamage -= OnTookDamage;
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

    private void OnTookDamage(int health)
    {
        _healthBar.value = health;
    }
}
