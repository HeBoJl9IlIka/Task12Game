using UnityEngine;
using DG.Tweening;
using TMPro;

public class AnimationMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private TMP_Text _play;
    [SerializeField] private TMP_Text _exit;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;

    private void Update()
    {
        if (_play.color != _targetColor)
            return;

        if (_menu.activeSelf == true)
            _menu.SetActive(false);
    }

    public void HideMenu()
    {
        _play.DOColor(_targetColor, _duration);
        _exit.DOColor(_targetColor, _duration);
    }
}
