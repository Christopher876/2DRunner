using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoad : MonoBehaviour {

	private GameObject Enemy;
	private GameObject stationary_enemy;
	private GameObject shooting_enemy;
	private GameObject moving_enemy;
	private GameObject enemy_null;

	public GameObject DecideEnemy()
	{
		int EnemyChoose = UnityEngine.Random.Range(0, 5);

		if(EnemyChoose == 1)
		{
			Enemy = stationary_enemy;
			Enemy.name = "stationary_enemy";
		}

		else if(EnemyChoose == 2)
		{
			Enemy = moving_enemy;
			Enemy.name = "moving_enemy";
		}

		else if(EnemyChoose == 3)
		{
			Enemy = shooting_enemy;
			Enemy.name = "trooper";
		}

		else
		{
			Enemy = enemy_null;
		}

		return Enemy;
	}

	// Use this for initialization
	void Start () {
		stationary_enemy = (GameObject)Resources.Load("Enemies/stationary_enemy");
		moving_enemy = (GameObject)Resources.Load("Enemies/moving_enemy");
		enemy_null = (GameObject)Resources.Load("Enemies/enemy_null");
		shooting_enemy = (GameObject)Resources.Load("Enemies/shooting_enemy");

		//stationary_enemy = GameObject.Find("stationary_enemy");
		//stationary_enemy.SetActive(false);
	}
	
}
