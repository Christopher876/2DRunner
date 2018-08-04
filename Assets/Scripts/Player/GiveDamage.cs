using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour {

	public int Damage = 0;
	private GameObject player;

	private void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			Debug.Log("Doing");
			Damage = 1;
			player.GetComponent<Health>().TakeDamage(Damage);
		}
	}

}
