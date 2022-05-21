using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;

    public Player Target => _target;

    private void Start()
    {
        FixBag();
    }

    private void FixBag()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f); ;
    }
}
