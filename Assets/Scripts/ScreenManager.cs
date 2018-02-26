using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenManager : MonoBehaviour 
{
    public static int score;

    public void Start()
    {
        score = GameStats.Instance.score;
    }

    public void GoToMenu()
	{
        SceneManager.LoadScene(0);
	}

	public void GoToHowToPlay()
	{
        SceneManager.LoadScene(1);
	}

	public void GoToCredits()
	{
        SceneManager.LoadScene(2);
	}

    public void GoToStartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
