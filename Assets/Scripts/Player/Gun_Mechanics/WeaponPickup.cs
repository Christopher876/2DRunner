using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	private GameObject player;
	public GameObject gunOnGround;

	public void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player.GetComponent<Gun>().EquipGun(gunOnGround);
			Destroy(gameObject);
		}
	}

}
