using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }
    }

    public int enemyKillCount = 0;
    public int score = 0;
    public float playerHP = 100.0f;
    private float comboScore = 1.06f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Scoring()
    {
        enemyKillCount++;
        score = (int)((score + 100) * comboScore);
    }
}
