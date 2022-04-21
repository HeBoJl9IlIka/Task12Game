using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Object _object;

    public string Label => _label;
    public Sprite Icon => _icon;
    public Object Type => _object;

    public enum Object
    {
        GreenKeyCard,
        BlueKeyCard,
        RedKeyCard,
        ScrapMetal
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
