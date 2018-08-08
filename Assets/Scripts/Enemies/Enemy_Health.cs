using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	private int health = 3;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("3DamageBullet"))
		{
			Destroy(collision.gameObject);
			health = health - 1;
			if(health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
