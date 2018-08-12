using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class FileManager : MonoBehaviour {
	public GameObject player;

	private void Start()
	{
		Loadfile();
	}

	#region Saving data variables
	public float rankExperience;
	public int rank;
	public int baseHealth;
	public int score_multiplier;
	#endregion

	public void GetAllData()
	{
		//If I add more data to save, remember to add it to "GameData"
		baseHealth = gameObject.GetComponent<Health>().BaseHealth;
		rank = gameObject.GetComponent<Rank>().rank;
		rankExperience = gameObject.GetComponent<Rank>().rankExperience;
		score_multiplier = gameObject.GetComponent<Score>().score_multipler;
	}

	public void SaveFile()
	{
		string destination = Application.persistentDataPath + "/main_save.dat";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		GameData data = new GameData(baseHealth, rank, rankExperience, score_multiplier);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
		Debug.Log(destination);
		
	}

	public void Loadfile()
	{
		string destination = Application.persistentDataPath + "/main_save.dat";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.Log("FILE NOT FOUND");
			return;
		}

		BinaryFormatter bf = new BinaryFormatter();
		GameData data = (GameData)bf.Deserialize(file);
		file.Close();

		#region Applying the loaded variables to the right things
		player.GetComponent<Health>().BaseHealth = data.baseHealth;
		player.GetComponent<Rank>().rank = data.rank;
		player.GetComponent<Rank>().rankExperience = data.rankExperience;
		player.GetComponent<Score>().score_multipler = data.score_multiplier;
		#endregion
	}

}
