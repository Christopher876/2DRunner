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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Doing");
			Damage = 1;
			player.GetComponent<Health>().TakeDamage(Damage);
		}
	}

}
