using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour {

	private GameObject player;
	private float playerX;
	private float enemyX;
	private float seconds = 0.25f;

	private void Start()
	{
		player = GameObject.FindWithTag("Player");
		StartCoroutine(Repeat());
	}

	private void FindPlayerDistance()
	{
		playerX = player.transform.position.x;
		enemyX = transform.position.x;

		if (playerX > (enemyX +10))
		{
			Destroy(this.gameObject);
		}
	}

	private IEnumerator Repeat()
	{
		while (true)
		{
			FindPlayerDistance();
			yield return new WaitForSeconds(seconds);
			
		}
	}

}
