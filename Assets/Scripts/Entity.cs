using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour 
{
    public float speed;
    public Vector3 rotationSpeed;
    public Animator anim;
	public Rigidbody playerRigidbody;

    public virtual void Init(Vector3 position)
    {
    }

    public virtual void Move()
    {

    }
}