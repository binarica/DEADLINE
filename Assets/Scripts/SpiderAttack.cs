using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpiderKill))]
public class SpiderAttack : MonoBehaviour
{
    public AnimationClip attackAnimation;
    public AudioClip attackAudio;
    public AudioClip chargingAudio;
    public float attackRange = 2;
    public float attackDelay = 2;

    SpiderKill spiderKill;
    Transform player;
    bool isCharging = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spiderKill = GetComponent<SpiderKill>();
    }

    private bool IsInAttackRange
    {
        get { return Vector3.Distance(transform.position, player.position) < attackRange; }
    }

    void Update()
    {
        if (CanCharge)
            ChargeAttack();
    }

    private bool CanCharge
    {
        get { return IsInAttackRange && !isCharging && !spiderKill.IsDead; }
    }

    private bool CanAttack
    {
        get { return IsInAttackRange && !spiderKill.IsDead; }
    }

    private void ChargeAttack()
    {
        Invoke("Attack", attackDelay);
        //audio.PlayOneShot(chargingAudio);
        isCharging = true;
    }

    private void Attack()
    {
        isCharging = false;

        if (!CanAttack)
            return;

        //ActivateHittables.HitAll(player.gameObject);

        //animation.CrossFade(attackAnimation.name);

        //audio.PlayOneShot(attackAudio);
    }


}
