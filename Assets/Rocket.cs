using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Vector3 velocity;
    public int speed;
    public bool isLatched;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLatched)
        {

        }
        else
        {
            transform.position += new Vector3(speed * velocity.x, speed * velocity.y, 0) * Time.deltaTime;
        }

        transform.rotation = GetRotation();
    }

    private Quaternion GetRotation()
    {
        int zRotation;
        if (velocity.y > 0)
        { 
            zRotation = (int) (Math.Atan(-1 * velocity.x / velocity.y) * 180 / Math.PI);
        } 
        else
        {
            zRotation = 180 + (int)(Math.Atan(-1 * velocity.x / velocity.y) * 180 / Math.PI);
        }

        Quaternion rotation = Quaternion.Euler(0, 0, zRotation);

        return rotation;
    }
}
