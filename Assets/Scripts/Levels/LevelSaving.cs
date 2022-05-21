using UnityEngine;

public class LevelSaving : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private KeyCard _keyCard;
    [SerializeField] private int _numberLevel;

    private bool _isKeyCardRaised;

    private const string KeyCardTaken = "keyCardTaken"; 
    private const string True = "true";


    public bool IsKeyCardTaken
    {
        get
        {
            return PlayerPrefs.GetString(KeyCardTaken + _numberLevel) == True;
        }
        private set { }
    }

    private void OnEnable()
    {
        _keyCard.Disabled += OnDisabled;
    }

    private void OnDisable()
    {
        _keyCard.Disabled -= OnDisabled;
    }

    public void SaveData()
    {
        if(_isKeyCardRaised & _player.IsDead == false)
            PlayerPrefs.SetString(KeyCardTaken + _numberLevel, True);
    }

    private void OnDisabled()
    {
        _isKeyCardRaised = true;
    }
}
