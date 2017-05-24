using UnityEngine;
using System.Collections;

public class GrenadeBomb : MonoBehaviour
{	
	public float explosionTime;
	public GameObject explosionFeedback;
	public float damageDistance;
	public float damage;
	private int mask;

	void Start ()
    {
		Invoke("Explode", explosionTime);
		mask = (1 << Layers.ENEMY) | (1 << Layers.PLAYER);
	}

	public void Explode()
    {
		Collider[] colliders = Physics.OverlapSphere(transform.position, damageDistance, mask);
		int len = colliders.Length;
		Entity e;
		Rigidbody rb;
		
		for(int i = len - 1; i >= 0; i--)
        {
			rb = colliders[i].GetComponentInChildren<Rigidbody>();
			
			if(rb != null){
				rb.AddForce((colliders[i].transform.position - transform.position).normalized * 100 * damageDistance);
			}
			
			e = colliders[i].GetComponent<Entity>();
			//e.TakeDamage(damage);		
		}
		
		GameObject.Instantiate(explosionFeedback, transform.position, Quaternion.identity);
		GameObject.Destroy(this.gameObject);
	}
}
