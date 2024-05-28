using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetSpawner : MonoBehaviour
{
    private const float PLANET_SHIFT = 5.0f;

    public GameObject planetGameObject;
    public static int planetCount = 0;
    private Queue<GameObject> planets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 SpawnInitialPlanets()
    {
        GameObject firstPlanet = SpawnPlanet(2f, 2f);

        planets.Enqueue(firstPlanet);

        for (int i = 0; i< 3; i++)
        {
            SpawnNextPlanet();
        }

        return firstPlanet.transform.position;
    }

    public void SpawnNextPlanet()
    {
        float nextX = Random.Range(-5, 5);
        float nextY = planets.Last().transform.position.y + PLANET_SHIFT;

        GameObject planetObject = SpawnPlanet(nextX, nextY);

        planets.Enqueue(planetObject);
    }

    private GameObject SpawnPlanet(float nextX, float nextY)
    {
        Vector3 newPosition = new Vector3(nextX, nextY, 0);
        GameObject planetObject = Instantiate(planetGameObject, newPosition, Quaternion.identity);
        planetObject.GetComponent<Planet>().rotateSpeed = Random.Range(-20, 20);

        return planetObject;
    }

    public Vector3 GetNextOrbitPlanetPosition(Vector3 RocketPosition, Vector3 CurrentOrbitPlanetPosition)
    {
        return planets
            .Where(p => p.transform.position.y > RocketPosition.y && !p.transform.position.Equals(CurrentOrbitPlanetPosition))
            .First().transform.position;
    }

    public void CheckAndDestroyPlanet(float cameraLowestY)
    {
        while (planets.First().transform.position.y < (cameraLowestY - Planet.LARGEST_PLANET_RADIUS))
        {
            GameObject.Destroy(planets.Dequeue());
        }
    }
}