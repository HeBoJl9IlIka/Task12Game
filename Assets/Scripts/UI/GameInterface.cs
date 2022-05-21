using TMPro;
using UnityEngine;
using System.Collections;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private TMP_Text _robotCount;
    [SerializeField] private TMP_Text _scrapMetalCount;
    [SerializeField] private TMP_Text _greenKeyCardCount;
    [SerializeField] private TMP_Text _blueKeyCardCount;
    [SerializeField] private TMP_Text _redKeyCardCount;
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private GameObject _errorPanel;
    [SerializeField] private float _errorShowDuration;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        _playerWarehouse.AssembledRobot += OnAssembledRobot;
        _playerWarehouse.UsedGreenKeyCard += OnUsedGreenKeyCard;
        _playerWarehouse.UsedBlueKeyCard += OnUsedBlueKeyCard;
        _playerWarehouse.UsedRedKeyCard += OnUsedRedKeyCard;
    }

    private void OnEnable()
    {
        _playerWarehouse.AssembledRobot += OnAssembledRobot;
        _playerWarehouse.UsedGreenKeyCard += OnUsedGreenKeyCard;
        _playerWarehouse.UsedBlueKeyCard += OnUsedBlueKeyCard;
        _playerWarehouse.UsedRedKeyCard += OnUsedRedKeyCard;
        _playerWarehouse.NotEnoughMetal += OnNotEnoughMetal;
        _playerWarehouse.NotEnoughKeyCard += OnNotEnoughKeyCard;
    }

    private void OnDisable()
    {
        _playerWarehouse.AssembledRobot -= OnAssembledRobot;
        _playerWarehouse.UsedGreenKeyCard -= OnUsedGreenKeyCard;
        _playerWarehouse.UsedBlueKeyCard -= OnUsedBlueKeyCard;
        _playerWarehouse.UsedRedKeyCard -= OnUsedRedKeyCard;
        _playerWarehouse.NotEnoughMetal -= OnNotEnoughMetal;
        _playerWarehouse.NotEnoughKeyCard -= OnNotEnoughKeyCard;
    }

    private void OnAssembledRobot(int robotCount, int scrapMetalCount)
    {
        _robotCount.text = robotCount.ToString();
        _scrapMetalCount.text = "Собрать робота: " + _playerWarehouse.NeedScrapMetal + "/" + scrapMetalCount.ToString() + " (металлолома)" ;
    }

    private void OnUsedGreenKeyCard(int cardCount)
    {
        _greenKeyCardCount.text = cardCount.ToString();
    }

    private void OnUsedBlueKeyCard(int cardCount)
    {
        _blueKeyCardCount.text = cardCount.ToString();
    }

    private void OnUsedRedKeyCard(int cardCount)
    {
        _redKeyCardCount.text = cardCount.ToString();
    }

    private void OnNotEnoughMetal()
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ShowError("Недостаточно металлолома"));
    }

    private void OnNotEnoughKeyCard()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ShowError("Недостаточно ключ-карт"));
    }

    private IEnumerator ShowError(string error)
    {
        _errorText.text = error;
        _errorPanel.SetActive(true);

        yield return new WaitForSeconds(_errorShowDuration);

        _errorPanel.SetActive(false);
    }
}
