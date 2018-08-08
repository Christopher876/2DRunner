using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Moving_Enemy : MonoBehaviour {

	public int move_speed = 5;
	private Rigidbody2D rigidbody;

	private void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		rigidbody.velocity = new Vector3(-5,0,0);
	}
}
