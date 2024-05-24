using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rocketY = 0.0f;
    private float planetY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position.Set(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        float shift;
        if (rocketY < planetY)
        {
            shift = rocketY;
        }
        else
        {
            shift = planetY;
        }

        this.gameObject.transform.position.Set(this.gameObject.transform.position.x, shift + 20, 0);
    }

    public void UpdatePositionsForCamera(float rocketY, float planetY)
    {
        this.rocketY = rocketY;
        this.planetY = planetY;
    }

    public float GetLowestY()
    {


        return 0f;
    }
}
