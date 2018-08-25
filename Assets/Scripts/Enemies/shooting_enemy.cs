using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_enemy : MonoBehaviour {

	public GameObject bullet;
	public int bulletSpeed = -5;
	private GameObject shotBullet;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		shotBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,270));
		rb = shotBullet.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector3(bulletSpeed, 0, 0);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			collision.collider.GetComponent<Health>().TakeDamage(1);
		}
	}
}
