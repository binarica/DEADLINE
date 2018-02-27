using UnityEngine;
using System.Collections;

public class SpiderKill : MonoBehaviour, IKillable
{
    Transform player;

    public AudioClip deathSound;
    public AnimationClip deathAnimation;
    public bool IsDead { get; private set; }

    UnityEngine.AI.NavMeshAgent aiFollow;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aiFollow = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //   aiFollow = GetComponent<AIFollow>();
    }

    void Update()
    {
        aiFollow.SetDestination(player.position);
    }

    public void Kill()
    {
        IsDead = true;

        Destroy(gameObject, 2);
        //audio.PlayOneShot(deathSound);

        //animation.CrossFade(deathAnimation.name);
       // aiFollow.canMove = false;
    }
}
