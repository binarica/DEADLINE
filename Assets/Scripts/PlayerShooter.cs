using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    public int currentAmmo = 5;
    public int maxAmmo = 30;

    private float timer;
    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootableMask;
    private ParticleSystem gunParticles;
    private LineRenderer gunLine;
    private AudioSource audioSource;
    private Light gunLight;
    float effectsDisplayTime = 0.2f;

    public GameObject grenadeBomb;
    public float grenadeImpulse;
    public float grenadeTime;
    public float grenadeDamage;
    public float grenadeDamageRadius;

    public float coldDownTime;
    public float accuracy;

    public AudioClip shootSound;
    public AudioClip clickSound;

    protected bool isGrenadeReady = false;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Enemy");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunLight = GetComponent<Light> ();

        audioSource = GetComponent<AudioSource>();
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets * effectsDisplayTime)
            DisableEffects();

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
                Shoot();
        /*
        if (Input.GetButton("Fire2") && isGrenadeReady == true)
            throwGrenade();
        */
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        if (currentAmmo > 0)
        {         
            audioSource.clip = shootSound;
            audioSource.Play();

            gunLight.enabled = true;

            gunParticles.Stop ();
            gunParticles.Play ();

            gunLine.enabled = true;
            gunLine.SetPosition (0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            currentAmmo--;

            if (Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
                }
                gunLine.SetPosition (1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            }       
        }
        else
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }

    void throwGrenade()
    {
        GameObject go = (GameObject)GameObject.Instantiate(grenadeBomb, shootRay.origin + transform.forward * 1.5f, Quaternion.LookRotation(shootRay.direction));
        go.GetComponent<Rigidbody>().AddForce(shootRay.direction * grenadeImpulse);

        GrenadeBomb gb = go.GetComponent<GrenadeBomb>();
        gb.damage = grenadeDamage;
        gb.damageDistance = grenadeDamageRadius;
        gb.explosionTime = grenadeTime;

        Invoke("Ready", coldDownTime);
    }

    public void Ready()
    {
        isGrenadeReady = true;
    }
}
