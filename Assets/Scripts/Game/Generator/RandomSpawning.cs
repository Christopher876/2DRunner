using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject[] SpawnAreas;
    public List<GameObject> CurrentAreas;
    private float screenWidthinPoints;

    // Use this for initialization
    void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthinPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());
        Debug.Log("Done Start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddRoom(float FarthestAreaEndX)
    {
        int randomAreaIndex = Random.Range(0, SpawnAreas.Length);
        GameObject Area = (GameObject)Instantiate(SpawnAreas[randomAreaIndex]);
        float AreaWidth = Area.transform.Find("ground").localScale.x;
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
        float playerX = transform.position.x;
        float removeAreaX = playerX - screenWidthinPoints;
        float addAreaX = playerX + screenWidthinPoints;
        float FarthestAreaEndX = 0;
        //Debug.Log("Done starting");   

        foreach (var Area in CurrentAreas)
        {
            float AreaWidth = Area.transform.Find("ground").localScale.x;
            Debug.Log(AreaWidth);
            float AreaStartX = Area.transform.position.x - (AreaWidth * 0.5f);
            Debug.Log(AreaStartX);
            float AreaEndX = AreaStartX + AreaWidth;
            Debug.Log(AreaEndX);

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
        Debug.Log("Done Deciding");
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            DecidetoGenerate();
            yield return new WaitForSeconds(0.25f);
        }
    }
}


