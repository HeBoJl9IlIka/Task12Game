using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private TMP_Text _robotCount;
    [SerializeField] private TMP_Text _scrapMetalCount;
    [SerializeField] private TMP_Text _greenKeyCardCount;
    [SerializeField] private TMP_Text _blueKeyCardCount;
    [SerializeField] private TMP_Text _redKeyCardCount;

    private void OnEnable()
    {
        _playerWarehouse.AssembledRobot += OnAssembledRobot;
        _playerWarehouse.UsedGreenKeyCard += OnUsedGreenKeyCard;
        _playerWarehouse.UsedBlueKeyCard += OnUsedBlueKeyCard;
        _playerWarehouse.UsedRedKeyCard += OnUsedRedKeyCard;
    }

    private void OnDisable()
    {
        _playerWarehouse.AssembledRobot -= OnAssembledRobot;
        _playerWarehouse.UsedGreenKeyCard -= OnUsedGreenKeyCard;
        _playerWarehouse.UsedBlueKeyCard -= OnUsedBlueKeyCard;
        _playerWarehouse.UsedRedKeyCard -= OnUsedRedKeyCard;
    }

    private void OnAssembledRobot(int robotCount, int scrapMetalCount)
    {
        _robotCount.text = "Всего роботов: " + robotCount.ToString();
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
}
