using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position.Set(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(float rocketY, float planetY)
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
}
