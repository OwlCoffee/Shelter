using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public static DataManager Instance()
    {
        if (instance == null)
        {
            instance = new DataManager();
        }

        return instance;
    }

    public int enemyKillCount = 0;
    public int score = 0;

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
        score += 100;
    }
}
