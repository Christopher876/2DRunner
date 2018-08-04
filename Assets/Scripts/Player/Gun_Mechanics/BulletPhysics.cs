using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour {

	private GameObject player;
	private float BulletSpeed;

	private void Start()
	{
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		player = GameObject.FindWithTag("Player");
		BulletSpeed = player.GetComponent<Gun>().BulletSpeed;
	}

	private void Update()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void FixedUpdate () {
		float thisposition = gameObject.transform.position.x;
		if (thisposition > (player.transform.position.x + 15))
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.GetComponent<Collider2D>().gameObject);
			Destroy(gameObject);
		}
	}
}
