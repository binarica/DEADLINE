using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public static bool paused = false;

    //public GameObject pausedTexture;

    private MouseLook characterMouseLook, cameraMouseLook;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //APB.
        characterMouseLook = GameObject.Find("First Person Controller").GetComponent<MouseLook>();
        cameraMouseLook = Camera.main.GetComponent<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }

            //pausedTexture.SetActive(!paused);
            cameraMouseLook.enabled = paused;
            characterMouseLook.enabled = paused;
            paused = !paused;
        }
    }
}