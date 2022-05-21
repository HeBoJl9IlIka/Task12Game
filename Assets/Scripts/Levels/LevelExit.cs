using UnityEngine;
using UnityEngine.Events;

public class LevelExit : MonoBehaviour
{
    public UnityEvent PlayerLeft; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerLeft?.Invoke();
        }
    }
}
