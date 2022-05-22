using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.Events;

public class LoadingBaseScene : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Player _player;

    public UnityEvent Uploaded;

    public void Load()
    {
        if (_player.IsDead)
        {
            Base.Load(_player.IsDead);
        }
        else
        {
            Base.Load(_playerInventory.GetItems());
        }

        Uploaded?.Invoke();
    }
}
