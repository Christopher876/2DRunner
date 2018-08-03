using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveHealth : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player.GetComponent<Health>().AddHeart(1);
			Destroy(this.gameObject);
		}
	}
}
