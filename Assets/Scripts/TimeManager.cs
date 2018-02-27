using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static float timeLeft;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        timeLeft = 200;
    }

    void Update()
    {
        text.text = "Time: " + (int)timeLeft; 
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            timeLeft = 0;
            Invoke("GameOver", 1);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        ScreenManager.score += ScoreManager.score;
    }
}