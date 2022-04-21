using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWarehouse : DataTransfer
{
    [SerializeField] private GameSaving _gameSaving;
    [SerializeField] private int _needScrapMetal;
    [SerializeField] private int _defaultRobotCount;

    public int NeedScrapMetal => _needScrapMetal;
    public int RobotCount { get; private set; }

    public UnityAction<int, int> AssembledRobot;
    public UnityAction<int> UsedGreenKeyCard;
    public UnityAction<int> UsedBlueKeyCard;
    public UnityAction<int> UsedRedKeyCard;

    public enum KeyCardColor
    {
        Green,
        Blue,
        Red
    }

    private void Start()
    {
        LoadData();

        if (_gameSaving.IsFirstStart)
        {
            RobotCount += _defaultRobotCount;
            _gameSaving.SetData();
        }

        if (RobotIsDead == true)
        {
            DeleteRobot();
        }

        AssembledRobot?.Invoke(RobotCount, ScrapMetalCount);
        UsedGreenKeyCard?.Invoke(GreenKeyCardCount);
        UsedBlueKeyCard?.Invoke(BlueKeyCardCount);
        UsedRedKeyCard?.Invoke(RedKeyCardCount);
    }

    public void TryAddRobot()
    {
        if (ScrapMetalCount >= _needScrapMetal)
            AssembledRobot?.Invoke(++RobotCount, ScrapMetalCount - _needScrapMetal);
    }

    public bool TryUseKeyCard(KeyCardColor keyCardColor)
    {
        bool isKeyCard = false;

        switch (keyCardColor)
        {
            case KeyCardColor.Green:
                isKeyCard = CheckForCards(GreenKeyCardCount);
                if (isKeyCard)
                {
                    UsedGreenKeyCard?.Invoke(--GreenKeyCardCount);
                }
                break;
            case KeyCardColor.Blue:
                isKeyCard = CheckForCards(BlueKeyCardCount);
                if (isKeyCard)
                {
                    UsedBlueKeyCard?.Invoke(--BlueKeyCardCount);
                }
                break;
            case KeyCardColor.Red:
                isKeyCard = CheckForCards(RedKeyCardCount);
                if (isKeyCard)
                {
                    UsedRedKeyCard?.Invoke(--RedKeyCardCount);
                }
                break;
        }
        return isKeyCard;
    }

    private bool CheckForCards(int CardCount)
    {
        return CardCount > 0;
    }
    private void LoadData()
    {
        _gameSaving.GetItemsData(out int greenKeyCard, out int blueKeyCard, out int redKeyCard, out int scrapMetal, out int robotCount);

        GreenKeyCardCount += greenKeyCard;
        BlueKeyCardCount += blueKeyCard;
        RedKeyCardCount += redKeyCard;
        ScrapMetalCount += scrapMetal;
        RobotCount += robotCount;
    }

    private void DeleteRobot()
    {
        --RobotCount;
    }
}
