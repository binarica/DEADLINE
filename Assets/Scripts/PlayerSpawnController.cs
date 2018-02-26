using UnityEngine;
using System.Collections;

public class PlayerSpawnController : MonoBehaviour 
{
public GameObject[] playerSpawnArray; //This is our playerSpawn variable, it is an array. An array is a list.
private int randSpawnID;	
	void Awake()
	{
		playerSpawnArray = GameObject.FindGameObjectsWithTag("PlayerSpawn");
	}
	// Use this for initialization
	void Start () 
	{
		GetRandomPlayerSpawn();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public GameObject GetRandomPlayerSpawn()
	{
		randSpawnID = Random.Range(0, (playerSpawnArray.Length));
		print("SpawnID : " + randSpawnID);
		return playerSpawnArray[randSpawnID];
	}
}
