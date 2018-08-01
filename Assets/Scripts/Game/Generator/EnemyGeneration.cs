using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour {

	public int spawn_max = 5;
	private int RandomSpawnPoint;
	private int EnemyPick;
	public int spawn_EnemyPick_max = 5;
	//private GameObject TheEnemy = (GameObject)Resources.Load("Prefabs/stationary_enemy", typeof(GameObject));
	/*
	public static class Enemies{
		public string TheEnemy = (GameObject)Resources.Load("Prefabs/stationary_enemy", typeof(GameObject));
	}

	public void EnemyChoice()
	{
		EnemyPick = UnityEngine.Random.Range(0, spawn_max);
		if(EnemyPick >=0 && EnemyPick <= 5)
		{
			GameObject Enemy = Enemies.TheEnemy;
		}
	}*/

	public void Start()
	{
		
		DecideRandomSpawn();
		FindSpawn();
		//SpawnEnemy();
	}

	private void SpawnEnemy(Transform child)
	{
		//Instantiate((Resources.Load<GameObject>(Enemies.TheEnemy)), new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity);
		Instantiate(GameObject.Find("stationary_enemy"), new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity);
	}

	void DecideRandomSpawn()
	{
		RandomSpawnPoint = UnityEngine.Random.Range(0, spawn_max);
		Debug.Log(RandomSpawnPoint);
	}

	void FindSpawn()
	{
		int i = 1;
		foreach(Transform child in transform)
		{
			//compare = child.ToString();
			if(child.name == ("spawn_area_" + i) && (i == RandomSpawnPoint))
			{
				Debug.Log("spawned at " + child.name);
				SpawnEnemy(child);
			}
			else if(child.name == ("spawn_area_" + i))
			{
				Debug.Log("not spawn point");
				i++;
			}
		}
	}


}
