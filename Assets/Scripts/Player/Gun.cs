using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public Image gun;
	public Sprite gun_placeholder;
	
	void Start () {
		gun.sprite = gun_placeholder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
