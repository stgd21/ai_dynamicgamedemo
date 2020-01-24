using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee
{
    public Kinematic character;
    public Kinematic target;

    float maxAcceleration = 4f;


    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //Get direction to target
        result.linear = character.transform.position - target.transform.position;
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}
