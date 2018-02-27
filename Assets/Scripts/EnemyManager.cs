using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	private GameObject[] enemies;
	public GameObject enemyPrefab;
	public float DeltaPositionForSpawn = 150;

	void Update () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		if (enemies.Length < 6) {
			GameObject go = (GameObject)GameObject.Instantiate(enemyPrefab);
			go.transform.position = new Vector3 (Camera.main.transform.position.x + Random.Range(-DeltaPositionForSpawn, DeltaPositionForSpawn), 6,  Camera.main.transform.position.x + Random.Range(-DeltaPositionForSpawn, DeltaPositionForSpawn));                       
		}
	}
}
