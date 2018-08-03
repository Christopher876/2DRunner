using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoad : MonoBehaviour {

	public GameObject Enemy;
	public GameObject stationary_enemy;

	public GameObject DecideEnemy()
	{
		int EnemyChoose = UnityEngine.Random.Range(0, 5);

		//if(EnemyChoose == 1)
		//{
			Enemy = stationary_enemy;

		//}

		//Enemy.AddComponent<DespawnEnemy>();
		//Enemy.AddComponent<Rigidbody2D>();
		return Enemy;
	}

	// Use this for initialization
	void Start () {
		stationary_enemy = GameObject.Find("stationary_enemy");
		stationary_enemy.SetActive(false);
	}
	
}
