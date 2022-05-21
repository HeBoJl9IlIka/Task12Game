using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerTakingSound : MonoBehaviour
{
    [SerializeField] private PlayerTaking _playerTaking;

    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _playerTaking.Took += OnTook;
    }

    private void OnDisable()
    {
        _playerTaking.Took -= OnTook;
    }

    private void OnTook()
    {
        _sound.Play();
    }
}
