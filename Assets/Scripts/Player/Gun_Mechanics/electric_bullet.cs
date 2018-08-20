using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electric_bullet : MonoBehaviour {

	public float BulletSpeed;
	public GameObject player;
	public GameObject Enemies;
	private Rigidbody2D rb;
	private bool isSlowed = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		BulletSpeed = player_movement.playerSpeed * 2;
		Coroutine slowDown = StartCoroutine(SlowDownBullet());
		Debug.Log("Speed: " + BulletSpeed);
	}

	public void FixedUpdate()
	{
		rb.velocity = new Vector2(BulletSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	IEnumerator SlowDownBullet()
	{
		yield return new WaitForSeconds(0.7f);
		if (!isSlowed)
		{ 
			Debug.Log("slowed");
			BulletSpeed = player_movement.playerSpeed;
			isSlowed = true;
		}

	}

}
