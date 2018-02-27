using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;

    public GameObject explosionFeedback;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();
        currentHealth -= amount;  
        
        //hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Kill ();
        }
    }

    void Kill ()
    {
        isDead = true;

        GameObject.Instantiate(explosionFeedback, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        ScoreManager.score += scoreValue;
        EnemyCounter.totalEnemies -= 1;

        //capsuleCollider.isTrigger = true;
        gameObject.SetActive(false);
    }
}
