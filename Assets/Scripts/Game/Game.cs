using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameSaving _gameSaving;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _base;

    private void Awake()
    {
        _mainMenu.SetActive(_gameSaving.IsFirstStart);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
