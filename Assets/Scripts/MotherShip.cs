using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour 
{
	public int collectedEnergy = 0;
	public int neededEnergy;

	public GameObject[] energy;
	public int totalEnergy;

	public float difficultyPercentage = 0.5f;
	
	private PlayerInventory playerInventory;

	private Animator anim;

	public float restartDelay = 3f;
	private float restartTimer;
	
	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
		energy = GameObject.FindGameObjectsWithTag("Energy");
		totalEnergy = energy.Length;
		neededEnergy = Mathf.RoundToInt (totalEnergy * difficultyPercentage);
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
	}

	void Update()
	{
		if(totalEnergy < neededEnergy || collectedEnergy == neededEnergy)
		{
			anim.SetTrigger("IsGameOver");

			restartTimer+= Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if(playerInventory.collectedEnergy != 0)
			{
				collectedEnergy += playerInventory.collectedEnergy;
				playerInventory.collectedEnergy = 0;
			}
			
			if(collectedEnergy == neededEnergy)
			{
                Application.LoadLevel(4);
			}
		}
	}
}
