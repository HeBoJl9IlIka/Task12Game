using UnityEngine;
using UnityEngine.Events;

public class PlayerWarehouse : DataTransfer
{
    [SerializeField] private GameSaving _gameSaving;
    [SerializeField] private AdSettings _adSettings;
    [SerializeField] private int _needScrapMetal;
    [SerializeField] private int _defaultRobotCount;

    public int NeedScrapMetal => _needScrapMetal;
    public int RobotCount { get; private set; }

    public event UnityAction<int, int> AssembledRobot;
    public event UnityAction<int> UsedGreenKeyCard;
    public event UnityAction<int> UsedBlueKeyCard;
    public event UnityAction<int> UsedRedKeyCard;
    public event UnityAction NotEnoughMetal;
    public event UnityAction NotEnoughKeyCard;

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
            RobotCount = _defaultRobotCount;
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

    private void OnEnable()
    {
        _adSettings.VideoFinished += OnVideoFinished;
    }

    private void OnDisable()
    {
        _adSettings.VideoFinished -= OnVideoFinished;
    }

    public void TryAddRobot()
    {
        if (ScrapMetalCount >= _needScrapMetal)
            AssembledRobot?.Invoke(++RobotCount, ScrapMetalCount -= _needScrapMetal);
        else
            NotEnoughMetal?.Invoke();
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

    private bool CheckForCards(int cardCount)
    {
        if (cardCount == 0)
        {
            NotEnoughKeyCard?.Invoke();
        }

        return cardCount > 0;
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

    private void OnVideoFinished(double scrapMetalCount)
    {
        ScrapMetalCount += (int)scrapMetalCount;
        AssembledRobot?.Invoke(RobotCount, ScrapMetalCount);
    }
}
