using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public abstract class DataTransfer : MonoBehaviour, ISceneLoadHandler<Item[]>, ISceneLoadHandler<bool>
{
    public int GreenKeyCardCount { get; protected set; }
    public int BlueKeyCardCount { get; protected set; }
    public int RedKeyCardCount { get; protected set; }
    public int ScrapMetalCount { get; protected set; }
    public bool RobotIsDead { get; private set; }

    public void OnSceneLoaded(Item[] items)
    {
        foreach (var item in items)
        {
            switch (item.Type)
            {
                case Item.Object.GreenKeyCard:
                    GreenKeyCardCount++;
                    break;
                case Item.Object.BlueKeyCard:
                    BlueKeyCardCount++;
                    break;
                case Item.Object.RedKeyCard:
                    RedKeyCardCount++;
                    break;
                case Item.Object.ScrapMetal:
                    ScrapMetalCount++;
                    break;
            }
        }
    }

    public void OnSceneLoaded(bool robotIsDead)
    {
        RobotIsDead = robotIsDead;
    }
}
