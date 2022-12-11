using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private Text killCountText;
    private Text scoreText;
    private Text hpText;

    public Character player;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            if (killCountText != null)
            {
                killCountText.text = "Kill Count : " + DataManager.Instance.enemyKillCount;
                scoreText.text = "Score : " + DataManager.Instance.score;
                hpText.text = "Health : " + DataManager.Instance.playerHP;
            }
            else
            {
                FindText();
            }
        }
    }

    private void FindText()
    {
        Text[] texts = FindObjectsOfType<Text>();
        killCountText = texts[0];
        scoreText = texts[1];
        hpText = texts[2];
    }
}
