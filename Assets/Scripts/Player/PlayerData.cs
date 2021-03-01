using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int score;

    public PlayerData()
    {
        level=GlobalControl.Instance.level;
        score = GlobalControl.Instance.score;
    }
}
