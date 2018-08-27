using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electric_bullet_target : MonoBehaviour {
	public GameObject target;
	public Rigidbody2D rb;
	public GameObject Enemies;

	private float speed = 5f;
	private float rotateSpeed = 200f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		Enemies = GameObject.Find("Enemies");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		timer += Time.deltaTime;
		if(timer > 1f)
		{
			target = GameObject.FindGameObjectWithTag("Enemy");
			timer = 0;
		}
		float step = speed * Time.deltaTime;
		if (target != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
		}
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
