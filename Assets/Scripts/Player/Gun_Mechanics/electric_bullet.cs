using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electric_bullet : MonoBehaviour {

	public float BulletSpeed;
	public GameObject player;
	private bool isSlowed = false;

	private void Start()
	{
		BulletSpeed = player.GetComponent<player_movement>().playerSpeed * 2;
		StartCoroutine(SlowDownBullet());
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		Debug.Log("Speed: " + BulletSpeed);
	}

	public void Update()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<player_movement>().playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	IEnumerator SlowDownBullet()
	{
		yield return new WaitForSeconds(0.8f);
		if (!isSlowed)
		{ 
			Debug.Log("slowed");
			BulletSpeed = player.GetComponent<player_movement>().playerSpeed;
			isSlowed = true;
			//StartCoroutine(KeepBulletSpeedUp());
		}

	}

	IEnumerator KeepBulletSpeedUp()
	{
		while (true) { 
			BulletSpeed = player.GetComponent<player_movement>().playerSpeed;
			Debug.Log("sped up: " + BulletSpeed);
			yield return new WaitForSeconds(2);
		}
	}

}
