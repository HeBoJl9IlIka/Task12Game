using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LoadingBaseScene : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Player _player;

    public void LoadBaseScene()
    {
        if (_player.IsDead)
        {
            Base.Load(_player.IsDead);
        }
        else
        {
            Base.Load(_playerInventory.GetItems().ToArray());
        }
    }
}
