using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour {

	public float toNextRank;
	public float rankExperience;
	public float score;
	private float theScore;
	public int time;
	public int rank;
	public Text rankValue;

	private void Start()
	{
		rankValue.text = rank.ToString();
	}

	private void PromoteToNextRank()
	{
		if(rankExperience > toNextRank)
		{
			rank++;
			Debug.Log("Promoted to rank " + rank);
			Debug.Log("Rank Experience: " + rankExperience);
			rankExperience = rankExperience - toNextRank;
		}

		else
		{
			Debug.Log("Rank Experience: " + rankExperience);
		}
	}

	private void NextRank()
	{
		toNextRank = 2000;
		toNextRank = (toNextRank * rank);
		toNextRank = toNextRank * 0.5f;
		float NextRankExperience = Mathf.Round(toNextRank);
		Debug.Log("Experience = " + NextRankExperience);
	}

	private void CalculateRank()
	{
		score = gameObject.GetComponent<Score>().score;
		time = Score.TimeOnField;

		rankExperience = score * (time/10);
	}

	public void Begin()
	{
		CalculateRank();
		NextRank();
		PromoteToNextRank();
	}
}
