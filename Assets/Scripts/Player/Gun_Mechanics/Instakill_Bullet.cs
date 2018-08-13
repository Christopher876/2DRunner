using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill_Bullet : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.GetComponent<Collider2D>().gameObject);
			Destroy(gameObject);
		}
	}
}
