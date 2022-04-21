using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoading : MonoBehaviour
{
    public void LoadLevel1()
    {
        Level1.Load();
    }
    
    public void LoadLevel2()
    {
        Level2.Load();
    }
}
