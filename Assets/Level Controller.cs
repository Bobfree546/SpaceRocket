using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms.Impl;

public class LevelController : MonoBehaviour
{
    //private static int score = 0;

    private OrbitController orbitController;
    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = GetComponent<CameraController>();
        orbitController = GetComponent<OrbitController>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraController.UpdatePositionsForCamera(orbitController.GetRocketPosition().y, orbitController.GetCurrPlanetPos().y);
        orbitController.CheckAndDestroyPlanet(cameraController.GetLowestY());
    }
}
