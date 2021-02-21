using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{

    public int[][] starArr = new int[16][];
    // arr[level][[star][item][unlock]]
    public void SaveData(int level, int star, int itemCount, int unlock)
    {
        if (starArr[level - 1][0] < star)
            starArr[level - 1][0] = star;
        if (starArr[level - 1][1] > itemCount)
            starArr[level - 1][1] = itemCount;
        starArr[level - 1][2] = unlock;
    }

    public LevelData()
    {
        for (int i = 0; i < 16; i++)
        {
            starArr[i] = new int[3];
        }
    }
}
