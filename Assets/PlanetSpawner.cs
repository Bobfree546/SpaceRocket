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
    private Queue<GameObject> planets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlanet()
    {
        float nextX = Random.Range(-5, 5);
        float nextY = planets.Last().transform.position.y + PLANET_SHIFT;

        Vector3 newPosition = new Vector3(nextX, nextY, 0);
        GameObject planetObject = Instantiate(planetGameObject, newPosition, Quaternion.identity);
        planetObject.GetComponent<Planet>().rotateSpeed = Random.Range(-20, 20);

        planets.Enqueue(planetObject);
    }

    Vector3 GetNextOrbitPlanetPosition(Vector3 RocketPosition, Vector3 CurrentOrbitPlanetPosition)
    {
        return planets
            .Where(p => p.transform.position.y > RocketPosition.y && !p.transform.position.Equals(CurrentOrbitPlanetPosition))
            .First().transform.position;
    }

    void CheckAndDestroyPlanet(float cameraLowestY)
    {
        while (planets.First().transform.position.y < (cameraLowestY - Planet.LARGEST_PLANET_RADIUS))
        {
            GameObject.Destroy(planets.Dequeue());
        }
    }
}