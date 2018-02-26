using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
	private GameObject player;
	
	private PlayerSpawnController playerSpawnCTRL;
	
	private GameObject randPlayerSpawn;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerSpawnCTRL = GameObject.FindGameObjectWithTag("PlayerSpawnCTRL").GetComponent<PlayerSpawnController>();
	}
	// Use this for initialization
	void Start () 
	{
		randPlayerSpawn = playerSpawnCTRL.GetRandomPlayerSpawn();
		SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void SpawnPlayer()
	{
		player.transform.position = randPlayerSpawn.transform.position;
		print("You have spawn at " + randPlayerSpawn.name);
	}
}
