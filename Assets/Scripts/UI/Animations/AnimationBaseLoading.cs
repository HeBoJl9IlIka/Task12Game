using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class AnimationBaseLoading : MonoBehaviour
{
    [SerializeField] private TMP_Text _showingLoading;
    [SerializeField] private string[] _texts;
    [SerializeField] private float _defaultDelay;
    [SerializeField] private float _targetDelay;
    [SerializeField] private float _delayReduction;

    private Coroutine _corruntCoroutine;

    public UnityAction Ended;

    public void Start()
    {
        if (_corruntCoroutine != null)
            StopCoroutine(_corruntCoroutine);

        _corruntCoroutine = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        float delay = _defaultDelay;

            foreach (var text in _texts)
            {
                _showingLoading.text += "\n" + text;
                if (delay > _targetDelay)
                {
                    delay -= _delayReduction;
                }

                yield return new WaitForSeconds(delay);
            }

            Ended?.Invoke();
    }
}
