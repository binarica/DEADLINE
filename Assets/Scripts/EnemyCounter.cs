using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public static int totalEnemies;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        totalEnemies = 10;
    }

    void Update()
    {
        text.text = "Enemies Left: " + totalEnemies;

        if (totalEnemies < 1)
        {
            Invoke("NextLevel", 1);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
