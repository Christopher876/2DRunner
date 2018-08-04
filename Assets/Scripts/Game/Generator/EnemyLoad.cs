using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoad : MonoBehaviour {

	private GameObject Enemy;
	private GameObject stationary_enemy;

	public GameObject DecideEnemy()
	{
		int EnemyChoose = UnityEngine.Random.Range(0, 5);

		//if(EnemyChoose == 1)
		//{
			Enemy = stationary_enemy;
			Enemy.name = "stationary_enemy";

		//}

		return Enemy;
	}

	// Use this for initialization
	void Start () {
		stationary_enemy = (GameObject)Resources.Load("Enemies/stationary_enemy");


		//stationary_enemy = GameObject.Find("stationary_enemy");
		//stationary_enemy.SetActive(false);
	}
	
}
