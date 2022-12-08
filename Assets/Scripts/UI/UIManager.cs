using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }

            return instance;
        }
    }

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

    public Text killCountText;
    public Text scoreText;
    public Text hpText;

    public Character player;

    // Update is called once per frame
    void Update()
    {
        killCountText.text = "Kill Count : " + DataManager.Instance.enemyKillCount;
        scoreText.text = "Score : " + DataManager.Instance.score;
        hpText.text = "Player's HP : " + player.GetPlayerHP();
    }
}
