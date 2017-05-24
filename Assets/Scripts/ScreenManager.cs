using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenManager : MonoBehaviour 
{
	public void gotoMenu()
	{
        SceneManager.LoadScene(0);
	}

	public void gotoHowToPlay()
	{
        SceneManager.LoadScene(1);
	}

	public void gotoCredits()
	{
        SceneManager.LoadScene(2);
	}

    public void gotoStartGame()
    {
        SceneManager.LoadScene(3);
    }
}
