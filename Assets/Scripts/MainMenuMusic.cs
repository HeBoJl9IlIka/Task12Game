using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private GameSaving _gameSaving;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_gameSaving.IsFirstStart == false)
        {
            _audioSource.Play();
        }
    }
}
