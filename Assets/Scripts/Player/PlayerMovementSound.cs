using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementSound : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _playerMovement.Moved += OnMoved;
        _playerMovement.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _playerMovement.Moved -= OnMoved;
        _playerMovement.Stopped -= OnStopped;
    }

    private void OnMoved()
    {
        if (_sound.isPlaying)
            return;

        _sound.Play();
    }

    private void OnStopped()
    {
        _sound.Stop();
    }
}
