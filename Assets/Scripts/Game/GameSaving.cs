using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaving : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private Level[] _levels;

    private const string _greenKeyCard = "GreenKeyCard";
    private const string _blueKeyCard = "BlueKeyCard";
    private const string _redKeyCard = "RedKeyCard";
    private const string _scrapMetal = "ScrapMetal";
    private const string _robot = "Robot";
    private const string _false = "false";
    private const string _true = "true";
    private const string _first = "first";

    public bool IsFirstStart
    {
        get
        {
            return PlayerPrefs.GetString(_first) != _false;
        }

        private set { }
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        PlayerPrefs.SetString(_first, _false);
        SetItemsData();
        SetLevelData();
    }

    public void GetItemsData(out int greenKeyCard, out int blueKeyCard, out int redKeyCard, out int scrapMetal, out int robotCount)
    {
        greenKeyCard = PlayerPrefs.GetInt(_greenKeyCard);
        blueKeyCard = PlayerPrefs.GetInt(_blueKeyCard);
        redKeyCard = PlayerPrefs.GetInt(_redKeyCard);
        scrapMetal = PlayerPrefs.GetInt(_scrapMetal);
        robotCount = PlayerPrefs.GetInt(_robot);
    }

    public bool GetLevelData(Level level)
    {
        return PlayerPrefs.GetString(level.Number.ToString()) == _true;
    }

    private void SetItemsData()
    {
        PlayerPrefs.SetInt(_greenKeyCard, _playerWarehouse.GreenKeyCardCount);
        PlayerPrefs.SetInt(_blueKeyCard, _playerWarehouse.BlueKeyCardCount);
        PlayerPrefs.SetInt(_redKeyCard, _playerWarehouse.RedKeyCardCount);
        PlayerPrefs.SetInt(_scrapMetal, _playerWarehouse.ScrapMetalCount);
        PlayerPrefs.SetInt(_robot, _playerWarehouse.RobotCount);
    }

    private void SetLevelData()
    {
        foreach (var level in _levels)
        {
            PlayerPrefs.SetString(level.Number.ToString(), level.IsOpen ? _true : _false);
        }
    }
}
