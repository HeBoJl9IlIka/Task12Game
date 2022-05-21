using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoading : MonoBehaviour
{
    [SerializeField] private AnimationLevelLoading _animationLevelLoading;

    private int _levelNumber;

    private void OnEnable()
    {
        _animationLevelLoading.Ended += OnEnded;
    }

    private void OnDisable()
    {
        _animationLevelLoading.Ended -= OnEnded;
    }

    private void OnEnded()
    {
        switch (_levelNumber)
        {
            case 1:
                Level1.Load();
                break;
            case 2:
                Level2.Load();
                break;
            case 3:
                Level3.Load();
                break;
            case 4:
                Level4.Load();
                break;
            case 5:
                Level5.Load();
                break;
            case 6:
                Level6.Load();
                break;
            case 7:
                Level7.Load();
                break;
            case 8:
                Level8.Load();
                break;
            case 9:
                Level9.Load();
                break;
        }
    }

    public void SetLevelNumber(int levelNumber)
    {
        _levelNumber = levelNumber;
    }
}
