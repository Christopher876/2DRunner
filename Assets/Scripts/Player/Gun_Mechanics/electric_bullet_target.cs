using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electric_bullet_target : MonoBehaviour {
	public GameObject target;
	public Rigidbody2D rb;
	public GameObject Enemies;

	private float speed = 5f;
	private float rotateSpeed = 200f;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		Enemies = GameObject.Find("Enemies");
		target = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 direction = (Vector2)target.transform.position - rb.position;
		Debug.Log(direction);
		direction.Normalize();
		float rotateAmount = Vector3.Cross(direction, transform.up).z;
		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

	GameObject FindClosestEnemy()
	{
		GameObject bestTarget = null;
		float x, y, bulletX;

		foreach (Transform child in Enemies.transform)
		{
			x = child.transform.position.x;

			if (x < bestTarget.transform.position.x)
			{
				bestTarget = GameObject.Find(child.name);
			}

		}

		return bestTarget;
	}
}
