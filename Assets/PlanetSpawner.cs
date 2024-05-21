using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetGameObject;
    public static int planetCount = 0;
    private int nextY;

    // Start is called before the first frame update
    void Start()
    {
        nextY = 5;
    }

    // Update is called once per frame
    void Update()
    {
        while (planetCount < 3)
        {
            SpawnPlanet();
        }
    }

    void SpawnPlanet()
    {
        int nextX = Random.Range(-10, 10);

        planetCount++;

        Vector3 newPosition = new Vector3(nextX, nextY, 0);
        GameObject planetObject = Instantiate(planetGameObject, newPosition, Quaternion.identity);
        planetObject.GetComponent<Planet>().planetId = planetCount;
        planetObject.GetComponent<Planet>().rotateSpeed = Random.Range(-20,20);

        nextY += 5;
    }
}
