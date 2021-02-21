using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private Text levelText;
    [SerializeField] private int star;
    [SerializeField] private GameObject[] starObject;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = level.ToString();
        LoadLevel();
        for (int i = 0; i < star; i++)
        {
            starObject[i].SetActive(true);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level " + level);
    }

    public void LoadLevel()
    {
        LevelData data = SaveLoad.LoadSystem();
        if (level != 1)
        {
            if (data.starArr[level - 2][2] != 1)
            {
                this.gameObject.SetActive(false);
            }
        }
        this.star = data.starArr[level - 1][0];
    }
}
