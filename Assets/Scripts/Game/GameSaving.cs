using UnityEngine;

public class GameSaving : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private Level[] _levels;

    private const string GreenKeyCard = "GreenKeyCard";
    private const string BlueKeyCard = "BlueKeyCard";
    private const string RedKeyCard = "RedKeyCard";
    private const string ScrapMetal = "ScrapMetal";
    private const string Robot = "Robot";
    private const string False = "false";
    private const string True = "true";
    private const string FirstStart = "first";

    public bool IsFirstStart
    {
        get
        {
            return PlayerPrefs.GetString(FirstStart) != False;
        }

        private set { }
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        SetItemsData();
        SetLevelData();
    }

    public void SetSaveFirstStart()
    {
        PlayerPrefs.SetString(FirstStart, False);
    }

    public void GetItemsData(out int greenKeyCard, out int blueKeyCard, out int redKeyCard, out int scrapMetal, out int robotCount)
    {
        greenKeyCard = PlayerPrefs.GetInt(GreenKeyCard);
        blueKeyCard = PlayerPrefs.GetInt(BlueKeyCard);
        redKeyCard = PlayerPrefs.GetInt(RedKeyCard);
        scrapMetal = PlayerPrefs.GetInt(ScrapMetal);
        robotCount = PlayerPrefs.GetInt(Robot);
    }

    public bool GetLevelData(Level level)
    {
        return PlayerPrefs.GetString(level.Number.ToString()) == True;
    }

    private void SetItemsData()
    {
        PlayerPrefs.SetInt(GreenKeyCard, _playerWarehouse.GreenKeyCardCount);
        PlayerPrefs.SetInt(BlueKeyCard, _playerWarehouse.BlueKeyCardCount);
        PlayerPrefs.SetInt(RedKeyCard, _playerWarehouse.RedKeyCardCount);
        PlayerPrefs.SetInt(ScrapMetal, _playerWarehouse.ScrapMetalCount);
        PlayerPrefs.SetInt(Robot, _playerWarehouse.RobotCount);
    }

    private void SetLevelData()
    {
        foreach (var level in _levels)
        {
            PlayerPrefs.SetString(level.Number.ToString(), level.IsOpen ? True : False);
        }
    }
}
