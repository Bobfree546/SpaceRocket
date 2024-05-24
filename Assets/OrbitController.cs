using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public PlanetSpawner planetSpawner; 
    public Rocket rocket;

    private Vector3 currPlanetPos;

    // Start is called before the first frame update
    void Start()
    {
        planetSpawner.SpawnPlanet();
        //currPlanetPos = ps.GetPlanetPos
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 planetPos = planetSpawner.GetNextOrbitPlanetPosition(rocket.transform.position, currPlanetPos);

        rocket.SetPlanetPos(currPlanetPos);
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
