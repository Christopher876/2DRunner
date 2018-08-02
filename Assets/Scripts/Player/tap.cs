using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tap : MonoBehaviour {

	public float hold = 0.03f;
	public float release = 0.02f;
	private bool tapInput = false;
	public bool theCheck = true;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			theCheck = true;
			StartCoroutine(Check());
		}
		CalculateReleaseTime();
	}

	public void CalculateHoldTime()
	{
		hold += Time.deltaTime;
	}

	public void CalculateReleaseTime()
	{
		if (hold < release)
		{
			tapInput = true;
			Debug.Log("tap");
			Reset();
		}
	}

	private void Reset()
	{
		hold = 0.03f;
		tapInput = false;
		theCheck = false;
	}

	private IEnumerator Check()
	{
		Debug.Log("start");
		while (theCheck)
			CalculateHoldTime();
		yield return new WaitForSeconds(0);
	}

}
