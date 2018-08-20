using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public GameObject CurrentGun;
	public GameObject Bullet;
	private GameObject FiredBullet;


	public float BulletSpeed;
	public Image gun;
	public Text CurrentClip;
	public int AmmoClip;
	public int AmmoReserve;
	public int MaxClip;

	public bool HasGun = false;

	private void Start()
	{
		gun.enabled = false;
	}

	public void CheckforSameGun(GameObject gunOnGround)
	{
		if(gunOnGround.name == CurrentGun.name && gunOnGround.tag == "special_gun")
		{
			Debug.Log("special gun");
			AmmoClip = MaxClip;
			CurrentClip.text = AmmoClip.ToString();
			Destroy(gunOnGround);
		}

		else if(gunOnGround.name == CurrentGun.name)
		{
			Debug.Log("same gun");
			AmmoReserve = AmmoReserve + MaxClip;
			CurrentClip.text = AmmoClip.ToString() + "/" + AmmoReserve.ToString();
			Destroy(gunOnGround);
		}

		else
		{
			Destroy(CurrentGun);
			CurrentGun = Instantiate(gunOnGround, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
			CreateSprite();
			CheckGunProperties();
			Debug.Log("Equipped " + CurrentGun);
		}
	}

	public void CheckGunProperties()
	{
		if(CurrentGun.name == "Bren_LMG")
		{
			MaxClip = 30;
			AmmoClip = 30;
			BulletSpeed = 20;
			CurrentClip.text = AmmoClip.ToString() + "/" + AmmoReserve.ToString();
		}

		if(CurrentGun.name == "Electric_Gun")
		{
			Bullet = (GameObject)Resources.Load("Bullets/electric_bullet");
			MaxClip = 3;
			AmmoClip = 3;
			BulletSpeed = 20;
			CurrentClip.text = AmmoClip.ToString();
		}

	}

	public void EquipGun(GameObject gunOnGround)
	{

		if (HasGun)
		{
			CheckforSameGun(gunOnGround);
		}

		else{
			CurrentGun = Instantiate(gunOnGround, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
			CurrentGun.name = gunOnGround.name;
			Destroy(gunOnGround);
			CreateSprite();
			CheckGunProperties();
			HasGun = true;
			Debug.Log("Equipped " + CurrentGun);
		}
		
	}

	private void CreateSprite()
	{
		gun.sprite = CurrentGun.GetComponent<SpriteRenderer>().sprite;
		gun.enabled = true;
	}


	private void Reload()
	{
		if((AmmoReserve == 30) && (CurrentGun.name == "Bren_LMG"))
		{
			AmmoReserve = 0;
			AmmoClip = 30;
		}
		else
		{
			AmmoClip = AmmoReserve - MaxClip;
			AmmoReserve = AmmoReserve - AmmoClip;
		}
		CurrentClip.text = AmmoClip.ToString() + "/" + AmmoReserve.ToString();

	}

	public void shoot()
	{
		if (AmmoClip > 0 && HasGun == true)
		{
			FiredBullet = Instantiate(Bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(new Vector3(0, 0, -90)));
			//FiredBullet.AddComponent<Rigidbody2D>();
			//FiredBullet.AddComponent<BulletPhysics>();
			AmmoClip--;
			CurrentClip.text = AmmoClip.ToString() + "/" + AmmoReserve.ToString();
		}

		else if(AmmoClip == 0 && AmmoReserve > 0)
		{
			Debug.Log("Reloading");
			Reload();
		}

		else
		{
			DestroyGun();
		}

	}


	private void DestroyGun()
	{
		gun.enabled = false;
		Destroy(CurrentGun);
		CurrentGun = null;
		CurrentClip.text = null;
		gun.sprite = null;
		HasGun = false;
	}
}
