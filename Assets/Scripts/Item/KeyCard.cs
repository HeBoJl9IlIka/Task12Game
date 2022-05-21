using UnityEngine;

public class KeyCard : Item
{
    [SerializeField] private LevelSaving _levelsSaving;

    private void Awake()
    {
        if(_levelsSaving.IsKeyCardTaken)
            gameObject.SetActive(false);
    }
}
