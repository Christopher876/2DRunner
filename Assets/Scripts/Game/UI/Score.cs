using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text timeText;
	public float score = 0;
	public static int TimeOnField = 0;
	private float timer = 0.0f;
	public bool alive = true;

	public int score_multipler = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine(SecondsTimer());
		StartCoroutine(ScoreTimer());
	}
	
	// Update is called once per frame
	void Update () {
		setScoreText();
		setTime();
	}

	void setScoreText()
	{
		scoreText.text = score.ToString(); 
	}

	void scoreSystem()
	{
		score += score_multipler;
	}

	void setTime()
	{
		timeText.text = TimeOnField.ToString();
	}


	private IEnumerator SecondsTimer()
	{
		while (alive)
		{
			TimeOnField++;
			yield return new WaitForSeconds(1);
		}
	}

	private IEnumerator ScoreTimer()
	{
		while (alive)
		{
			scoreSystem();
			yield return new WaitForSeconds(0.1f);
		}
	}
}
