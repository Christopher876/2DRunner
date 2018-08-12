[System.Serializable]
public class GameData
{
	public float rankExperience;
	public int rank;
	public int baseHealth;
	public int score_multiplier;

	public GameData(int baseHealthInt, int rankInt, float rankExperienceFloat, int score_multiplierInt)
	{
		baseHealth = baseHealthInt;
		rank = rankInt;
		rankExperience = rankExperienceFloat;
		score_multiplier = score_multiplierInt;
	}

}
