using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class AnimationLevelLoading : MonoBehaviour
{
    [SerializeField] private PlayerWarehouse _playerWarehouse;
    [SerializeField] private TMP_Text _showingLoading;
    [SerializeField] private GameObject _container;
    [SerializeField] private string[] _successTexts;
    [SerializeField] private string[] _failureTexts;
    [SerializeField] private float _defaultDelay;
    [SerializeField] private float _targetDelay;
    [SerializeField] private float _delayReduction;

    private Coroutine _corruntCoroutine;

    public event UnityAction Ended;

    public void Run()
    {
        if (_corruntCoroutine != null)
            StopCoroutine(_corruntCoroutine);

        _corruntCoroutine = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        _showingLoading.text = "";
        float delay = _defaultDelay;

        if (_playerWarehouse.RobotCount > 0)
        {
            foreach (var text in _successTexts)
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
        else
        {
            foreach (var text in _failureTexts)
            {
                _showingLoading.text += "\n" + text;
                if (delay > _targetDelay)
                {
                    delay -= _delayReduction;
                }

                yield return new WaitForSeconds(delay);
            }

            Invoke(nameof(Hide), _targetDelay);
        }
    }

    private void Hide()
    {
        _container.SetActive(false);
    }
}
