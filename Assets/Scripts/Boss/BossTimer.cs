using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour {

	public float randomSpawnTime = 0;
	public GameObject boss;
	public GameObject parent;

	private void Start()
	{
		randomSpawnTime = Random.Range(90, 180);
	}

	void Update () {
		if( Score.TimeOnField == randomSpawnTime)
		{
			Instantiate(boss, parent.transform.position, Quaternion.identity, parent.transform);
		}
	}
}
