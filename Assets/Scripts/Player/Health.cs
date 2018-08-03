using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public int CurrentHealth = 1;
	public int BaseHealth = 1;
	public int DamageTaken = 0;
	public int AddHealth = 1;

	public int CurrentHearts = 1;

	public Image Heart;
	private Image NewHeart;
	
	void Update () {
		
	}

	public void TakeDamage(int DamageTaken)
	{
		RemoveHeart();
		CurrentHealth = CurrentHealth - DamageTaken;
		CheckHealth();
	}

	public void CheckHealth()
	{
		if (CurrentHealth <= 0)
		{
			Debug.Log("Died");
			SceneManager.LoadScene("SampleScene");
		}
	}

	public void AddHeart(int AddHealth)
	{
		CurrentHealth = CurrentHealth + AddHealth;
		NewHeart = Instantiate(Heart,new Vector3((Heart.transform.position.x + -27), Heart.transform.position.y), Quaternion.identity, Heart.transform);
		NewHeart.name = "NewHeart" + CurrentHealth;
		//Debug.Log("Health is " + CurrentHealth);
	}

	public void RemoveHeart()
	{
		GameObject HeartToDestroy = GameObject.Find("NewHeart" + CurrentHealth);
		Destroy(HeartToDestroy);
		Debug.Log("Current Health: " + CurrentHealth);
	}

}
