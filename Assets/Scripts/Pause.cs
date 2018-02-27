using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour
{
    public static bool paused = false;

    public Image pauseMenu;

    private MouseLook characterMouseLook, cameraMouseLook;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Time.timeScale = 1.0f;
                pauseMenu.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseMenu.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                paused = true;
            }
        }
    }
}