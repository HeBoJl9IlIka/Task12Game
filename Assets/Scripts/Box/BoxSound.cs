using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoxSound : MonoBehaviour
{
    [SerializeField] private Box[] _boxs;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        foreach (var box in _boxs)
        {
            box.Moved += OnMoved;
            box.Stopped += OnStopped;
        }
    }

    private void OnDisable()
    {
        foreach (var box in _boxs)
        {
            box.Moved -= OnMoved;
            box.Stopped -= OnStopped;
        }
    }

    private void OnMoved()
    {
        if (_audioSource.isPlaying)
            return;

        _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.Play();
    }

    private void OnStopped()
    {
        _audioSource.Stop();
    }
}
