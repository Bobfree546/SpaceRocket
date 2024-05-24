using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public PlanetSpawner planetSpawner;
    public GameObject rocket;

    private Vector3 currPlanetPos;

    // Start is called before the first frame update
    void Start()
    {
        currPlanetPos = planetSpawner.SpawnInitialPlanets();
        rocket = Instantiate(rocket, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        currPlanetPos = planetSpawner.GetNextOrbitPlanetPosition(rocket.transform.position, currPlanetPos);

        rocket.GetComponent<Rocket>().SetPlanetPos(currPlanetPos);
    }

    public void CheckAndDestroyPlanet(float cameraLowestY)
    {
        planetSpawner.CheckAndDestroyPlanet(cameraLowestY);
    }

    public Vector3 GetCurrPlanetPos()
    {
        return currPlanetPos;
    }

    public void SetCurrPlanetPos(Vector3 newPos)
    {
        currPlanetPos = newPos;
    }

    public Vector3 GetRocketPosition()
    {
        return rocket.transform.position;
    }
}
