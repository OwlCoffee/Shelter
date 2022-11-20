using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCountText;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        killCountText.text = "Kill Count : " + DataManager.Instance().enemyKillCount;
        scoreText.text = "Score : " + DataManager.Instance().score;
    }
}
