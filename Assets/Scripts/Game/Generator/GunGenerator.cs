using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGenerator : MonoBehaviour {

	private string RetrieveWeapon;
	public string weaponname = "";

	private GameObject Weapon;
	private GameObject RandomWeapon;
	private GameObject logic;

	private void Start()
	{
		FindWeaponSpawn();
	}

	void SpawnWeapon(Transform child)
	{
		GameObject CreateWeapon = Instantiate(Weapon, new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity,gameObject.transform);
		CreateWeapon.name = weaponname;
	}

	public string ChooseWeapon()
	{
		int RandomChoice = Random.Range(0, 200);

		//Chance for Bren LMG
		if(RandomChoice>0 && RandomChoice < 100)
		{
			Weapon = (GameObject)Resources.Load("Guns/Bren_LMG");
			weaponname = "Bren_LMG";
		}

		else if (RandomChoice>100 && RandomChoice<200)
		{
			Weapon = (GameObject)Resources.Load("Guns/Electric_Gun");
			weaponname = "Electric_Gun";
		}
		return weaponname;
	}


	void FindWeaponSpawn()
	{
		foreach(Transform child in transform)
		{
			if(child.name == "weapon_spawn_area")
			{
				//Weapon = logic.GetComponent<WeaponHolder>().ReturnWeapon(RetrieveWeapon);
				ChooseWeapon();
				SpawnWeapon(child);
			}
		}
	}
	
	
}
