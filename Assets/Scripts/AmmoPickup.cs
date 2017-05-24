using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour 
{
	PlayerShooter playerShooter;
    public int ammoAmount = 10;

    AudioClip clip;

    void Start()
	{
        playerShooter = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShooter>();
        clip = GetComponent<AudioSource>().clip;
    }

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
            AudioSource.PlayClipAtPoint(clip, transform.position);
            playerShooter.currentAmmo += ammoAmount;
			gameObject.SetActive(false);
		}
	}
}