using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public GameObject CurrentGun;
	public GameObject Bullet;
	private GameObject FiredBullet;


	public float BulletSpeed = 100;
	public Image gun;
	public Sprite gun_sprite;

	public bool HasGun = false;
	
	// Update is called once per frame

	public void EquipGun(GameObject gunOnGround)
	{
		CurrentGun = Instantiate(gunOnGround, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
		CreateSprite();
		HasGun = true;
		Debug.Log("Equipped " + CurrentGun);
	}

	private void CreateSprite()
	{
		gun.sprite = CurrentGun.GetComponent<SpriteRenderer>().sprite;
	}

	public void shoot()
	{
		FiredBullet = Instantiate(Bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
		FiredBullet.AddComponent<Rigidbody2D>();
		FiredBullet.AddComponent<BulletPhysics>();
		//FiredBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, FiredBullet.GetComponent<Rigidbody2D>().velocity.y);
	}
}
