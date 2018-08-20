using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour {

	public GameObject Enemies;
	public int spawn_max = 5;
	private int RandomSpawnPoint;
	private int EnemyPick;
	public int spawn_EnemyPick_max = 5;
	private GameObject EnemyHolder;
	private GameObject Enemy;


	public void Start()
	{
		EnemyHolder = GameObject.Find("enemy_loader");
		Enemies = GameObject.Find("Enemies");
		DecideRandomSpawn();
		FindSpawn();
		//SpawnEnemy();
	}

	private void SpawnEnemy(Transform child, GameObject Enemy)
	{
		//Instantiate((Resources.Load<GameObject>(Enemies.TheEnemy)), new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity);
		Instantiate(Enemy, new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity, Enemies.transform);
		Enemy.SetActive(true);
	}

	void DecideRandomSpawn()
	{
		RandomSpawnPoint = UnityEngine.Random.Range(0, spawn_max);
		//Debug.Log(RandomSpawnPoint);
	}

	void FindSpawn()
	{
		int i = 1;
		if (RandomSpawnPoint != 0)
		{
			foreach (Transform child in transform)
			{
				//compare = child.ToString();
				if (child.name == ("spawn_area_" + i) && (i == RandomSpawnPoint))
				{
					Enemy = EnemyHolder.GetComponent<EnemyLoad>().DecideEnemy();
					//Debug.Log("spawned at " + child.name);
					SpawnEnemy(child,Enemy);
				}
				else if (child.name == ("spawn_area_" + i))
				{
					//Debug.Log("not spawn point");
					i++;
				}
			}
		}
	}

}
