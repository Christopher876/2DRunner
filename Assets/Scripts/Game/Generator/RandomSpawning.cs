using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject[] SpawnAreas;
    public List<GameObject> CurrentAreas;
    private float screenWidthinPoints;
	public GameObject player;
	public GameObject logic;
	private GameObject[] SpawnPoints;

	private bool DecidedToGenerateGun = false;
	public GameObject Health;

	// Use this for initialization
	void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthinPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());

		//player_movement playerScript = player.GetComponent<player_movement>();
        //Debug.Log("Done Start");
    }


    void AddRoom(float FarthestAreaEndX)
    {
        int randomAreaIndex = Random.Range(0, SpawnAreas.Length);
		GameObject Area = (GameObject)Instantiate(SpawnAreas[randomAreaIndex]);
        float AreaWidth = Area.transform.Find("floor").localScale.x;
        float AreaCenter = FarthestAreaEndX + AreaWidth * 0.5f;
        Area.transform.position = new Vector3(AreaCenter, 0, 0);
		Area.AddComponent<EnemyGeneration>();
		DecideToGenerateWeapon(Area);
		DecideToGenerateHealth(Area);
		CurrentAreas.Add(Area);
	}

    private void DecidetoGenerate()
    {
       // Debug.Log("Trying Start");
        List<GameObject> AreasToRemove = new List<GameObject>();
        bool AddAreas = true;
        float playerX = player.transform.position.x;
        float removeAreaX = playerX - screenWidthinPoints;
        float addAreaX = playerX + screenWidthinPoints;
        float FarthestAreaEndX = 0;
        //Debug.Log("Done starting");   

        foreach (var Area in CurrentAreas)
        {
            float AreaWidth = Area.transform.Find("floor").localScale.x;
            //Debug.Log(AreaWidth);
            float AreaStartX = Area.transform.position.x - (AreaWidth * 0.5f);
            //Debug.Log(AreaStartX);
            float AreaEndX = AreaStartX + AreaWidth;
           // Debug.Log(AreaEndX);

            if (AreaStartX > addAreaX)
            {
                AddAreas = false;
            }

            if (AreaEndX < removeAreaX)
            {
                AreasToRemove.Add(Area);
            }

            FarthestAreaEndX = Mathf.Max(FarthestAreaEndX, AreaEndX);
        }

        foreach (var Area in AreasToRemove)
        {
            CurrentAreas.Remove(Area);
            Destroy(Area);
        }

        if (AddAreas)
        {
            AddRoom(FarthestAreaEndX);
        }
        //Debug.Log("Done Deciding");
    }

	private void DecideToGenerateWeapon(GameObject Area)
	{
		int RandomWeaponChance = UnityEngine.Random.Range(0, 100);
		if(RandomWeaponChance > 0 && RandomWeaponChance < 8)
		{
			Area.AddComponent<GunGenerator>();
			DecidedToGenerateGun = true;
		}
		else
		{
			DecidedToGenerateGun = false;
		}
	}

	private void DecideToGenerateHealth(GameObject Area)
	{
		if (DecidedToGenerateGun == false)
		{
			float RandomHealth = Random.Range(0, 100);

			if (RandomHealth > 0 & RandomHealth < 5)
			{
				foreach (Transform child in Area.transform)
				{
					if (child.name == "weapon_spawn_area")
					{
						Instantiate(Health, new Vector3((child.transform.position.x), child.transform.position.y), Quaternion.identity, Area.transform);
						Debug.Log("Spawned Health");
					}
				}
				
			}
		}
	}

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {

			float seconds = 0.25f;
            DecidetoGenerate();
			if (GameObject.Find("player").GetComponent<player_movement>().playerSpeed > 25)
			{
				yield return new WaitForSeconds(0);
			}
			else
			{
				yield return new WaitForSeconds(seconds);
			}
		}
    }
}


