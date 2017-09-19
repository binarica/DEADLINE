using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
		
	void Awake ()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
	}

    void Update ()
	{
        nav.SetDestination(player.position);
    }
}