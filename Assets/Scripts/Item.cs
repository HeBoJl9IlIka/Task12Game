using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _label;

    public string Label => _label;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
