using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Vector3 velocity;
    public float velocityConstant; // maybe dont need. if anything, should be replaced by mass of rocket, which changes accel and vel calculations
    public float accel = 0.3f;
    public float speed;
    public float gravConstant;
    public bool isOrbiting;
    // temp planet
    public Vector3 planetPos = new Vector3(2, 5, 0);

    private static float LATCH_ERROR = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckToOrbit();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOrbiting = !isOrbiting;
        }

        Debug.Log(isOrbiting);

        if (isOrbiting)
        {
            speed = GetOrbitSpeed();
            accel = GetAccel();

            Vector3 r = GetVectorToPlanet();

            float accelX = Vector3.Dot(r, new Vector3(1, 0, 0)) * accel;
            float accelY = Vector3.Dot(r, new Vector3(0, 1, 0)) * accel;

            velocity += new Vector3(accelX, accelY) * Time.deltaTime;

            Move();
        }
        else
        {
            Move();
        }

        transform.rotation = GetRotation();
    }

    private void Move()
    {
        transform.position += Time.deltaTime * velocityConstant * new Vector3(velocity.x, velocity.y, 0);
    }

    private Quaternion GetRotation()
    {
        int zRotation;
        if (velocity.y > 0)
        {
            zRotation = (int)(Math.Atan(-1 * velocity.x / velocity.y) * 180 / Math.PI);
        }
        else
        {
            zRotation = 180 + (int)(Math.Atan(-1 * velocity.x / velocity.y) * 180 / Math.PI);
        }

        Quaternion rotation = Quaternion.Euler(0, 0, zRotation);

        return rotation;
    }

    private float GetAccel()
    {
        return gravConstant / GetOrbitRadius();
    }

    private float GetOrbitSpeed()
    {
        float radius = GetOrbitRadius();

        float speed = (float) Math.Sqrt(accel * radius);

        return speed;
    }

    private float GetOrbitRadius()
    {
        // get latched planet's position

        float radius = Vector3.Distance(transform.position, planetPos);

        return radius;
    }

    private Vector3 GetVectorToPlanet()
    {
        return planetPos - transform.position;
    }

    private void CheckToOrbit()
    {
        // get planet's position

        Vector3 distVector = planetPos - transform.position;

        if (Vector3.Dot(distVector, velocity) <= LATCH_ERROR || Vector3.Dot(distVector, velocity) >= -LATCH_ERROR)
        {
            isOrbiting = true;
        }
        else
        {
            isOrbiting = false;
        }
    }
}
