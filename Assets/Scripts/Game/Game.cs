using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void DeletAllSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
