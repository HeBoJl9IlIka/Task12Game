using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class DataTransfer : MonoBehaviour, ISceneLoadHandler<Item[]>
{
    public void OnSceneLoaded(Item[] items)
    {
        string text = "";
        foreach (var item in items)
        {
            text += item.Label + ". ";
        }
        Debug.Log(text);
    }
}
