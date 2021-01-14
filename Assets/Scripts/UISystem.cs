using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private float baseTimer;
    [SerializeField] private float timer;
    [SerializeField] private Text timerText;
    [SerializeField] private Text winText;
    [SerializeField] private int itemCount;
    [SerializeField] private Text itemText;
    [SerializeField] private int[] score;
    [SerializeField] private GameObject[] stars;

    private void Start()
    {
        timer = baseTimer;
        timerText.text = "";
        winText.text = "";
        itemText.text = itemCount.ToString();
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }
    }

    public int GetItemCount()
    {
        return itemCount;
    }

    public void WinGame()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();

        }
        else
        {
            winText.text = "You Win";
            EndLevel();
        }
    }

    public void RestartTimer()
    {
        timer = baseTimer;
        timerText.text = "";
    }

    public void AddItem()
    {
        itemCount += 1;
        itemText.text = itemCount.ToString();
    }

    public void EndLevel()
    {
        if (itemCount <= score[0])
        {
            stars[0].SetActive(true);
        }
        if (itemCount <= score[1])
        {
            stars[1].SetActive(true);
        }
        stars[2].SetActive(true);
    }
}
