using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
	PlayerHealth playerHealth;
    public int healAmount = 25;

    AudioClip clip;

    void Start()
	{
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        clip = GetComponent<AudioSource>().clip;
    }

	void OnTriggerEnter(Collider c)
	{
        if (c.tag == "Player" && playerHealth.currentHealth < 100)
		{
            AudioSource.PlayClipAtPoint(clip, transform.position);
            playerHealth.currentHealth += healAmount;
			gameObject.SetActive(false);
		}
	}
}