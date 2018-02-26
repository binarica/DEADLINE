using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public AudioClip damageClip;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float fallSpeed = 0.15f;

    Animator anim;
    AudioSource playerAudio;

    PlayerShooter playerShooter;

    bool isDead;
    bool damaged;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerShooter = GetComponentInChildren <PlayerShooter> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (isDead)
        {
            transform.Translate(-Vector3.up * fallSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        playerAudio.clip = damageClip;
        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        GetComponent<FirstPersonController>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        playerShooter.DisableEffects ();
        playerShooter.enabled = false;

        //anim.SetTrigger ("Die");

        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        Invoke("RestartGame", 2);
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(4);
        ScreenManager.score += ScoreManager.score;
    }
}
