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
        SceneManager.LoadScene("Menu");
	}

	public void GoToHowToPlay()
	{
        SceneManager.LoadScene("HowToPlay");
	}

	public void GoToCredits()
	{
        SceneManager.LoadScene("Credits");
	}

    public void GoToStartGame()
    {
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
