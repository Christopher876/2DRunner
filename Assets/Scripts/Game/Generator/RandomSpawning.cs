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

	// Use this for initialization
	void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthinPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());

		//player_movement playerScript = player.GetComponent<player_movement>();
        //Debug.Log("Done Start");
    }

	public GameObject[] FindSpawnPoints()
	{
		GameObject[] SpawnPoints = new GameObject[5];
		SpawnPoints[0] = GameObject.Find("spawn_area_1");
		Debug.Log(SpawnPoints[0].transform.position.x);

		/*
		SpawnPoints.Add(GameObject.Find("spawn_area_1"));
		SpawnPoints.Add(GameObject.Find("spawn_area_2"));
		SpawnPoints.Add(GameObject.Find("spawn_area_3"));
		SpawnPoints.Add(GameObject.Find("spawn_area_4"));
		SpawnPoints.Add(GameObject.Find("spawn_area_5"));
		*/
		return SpawnPoints;
	}

    void AddRoom(float FarthestAreaEndX)
    {
        int randomAreaIndex = Random.Range(0, SpawnAreas.Length);
		GameObject Area = (GameObject)Instantiate(SpawnAreas[randomAreaIndex]);
        float AreaWidth = Area.transform.Find("floor").localScale.x;
        float AreaCenter = FarthestAreaEndX + AreaWidth * 0.5f;
        Area.transform.position = new Vector3(AreaCenter, 0, 0);
        CurrentAreas.Add(Area);
       // Debug.Log("Done Add");
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
			GameObject[] SpawnPoints=FindSpawnPoints();
			logic.GetComponent<RandomEnemySpawn>().Begin(SpawnPoints);
        }
        //Debug.Log("Done Deciding");
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


