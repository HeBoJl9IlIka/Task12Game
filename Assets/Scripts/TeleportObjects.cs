using UnityEngine;

public class TeleportObjects : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box box))
            box.transform.position = _targetPosition.position;
    }
}
