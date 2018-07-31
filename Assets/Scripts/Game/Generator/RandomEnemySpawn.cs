using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour {

	public int spawn_max = 5;
	public GameObject[] Enemies;
	public GameObject TheEnemy;
	public GameObject player;
	public List<GameObject> CurrentEnemies;
	public float timeToDespawn = 9;
	public float rampingTime = 9;

	public int addoffeset = 58;

	// Use this for initialization
	void Start () {
		GameObject TheEnemy = Resources.Load("stationary_enemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		CountDown();
	}

	void SpawnEnemy(GameObject[] SpawnPoints)
	{
		int RandomSpawnPoint = Random.Range(0, spawn_max);
		Debug.Log(RandomSpawnPoint);
		
		#region if-else statements for spawn

		if (RandomSpawnPoint == 0)
		{
			//Instantiate(TheEnemy,new Vector3((SpawnPoints[0].transform.position.x + addoffeset), SpawnPoints[0].transform.position.y),Quaternion.identity);
			Debug.Log(SpawnPoints[0]);
			Debug.Log("destroyed");
		}

		else if (RandomSpawnPoint == 1)
		{

		}
		else if (RandomSpawnPoint == 2)
		{

		}
		else if (RandomSpawnPoint == 3)
		{

		}
		else if (RandomSpawnPoint == 4)
		{

		}
		else if (RandomSpawnPoint == 5)
		{

		}
		#endregion
	}


	float CountDown()
	{
		List<GameObject> EnemiesToRemove = new List<GameObject>();
		timeToDespawn -= Time.deltaTime;
		if(timeToDespawn < (timeToDespawn / 0.33))
		{
			//foreach (var Enemy in CurrentEnemies)
			//{
				float EnemyDistance = player.transform.position.x - TheEnemy.transform.position.x;
				//Debug.Log("Enemy Distance is " + EnemyDistance);
			//}
		}
		/*
		if(timeToDespawn < 0)
		{
			foreach (var Enemy in EnemiesToRemove)
			{
				Destroy(Enemy);
				timeToDespawn = rampingTime;
			}
		}*/
		return timeToDespawn;
	}

	public void Begin(GameObject[] SpawnPoints)
	{
		//StartCoroutine(CountDownStart());
		SpawnEnemy(SpawnPoints);
	}

	private IEnumerator CountDownStart()
	{
		while (true)
		{
			CountDown();
		}
	}
}
