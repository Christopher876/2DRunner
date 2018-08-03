using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour {

	private GameObject player;

	private void Start()
	{
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		//gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 20);
		player = GameObject.FindWithTag("Player");
	}

	private void Update()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(20, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void FixedUpdate () {
		float thisposition = gameObject.transform.position.x;
		if (thisposition > (player.transform.position.x + 15))
		{
			Destroy(gameObject);
		}
	}
}
