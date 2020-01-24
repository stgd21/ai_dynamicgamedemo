using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek
{
    public Kinematic character;
    public Kinematic target;

    float maxAcceleration = 4f;

    
    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //Get direction to target
        result.linear = target.transform.position - character.transform.position;
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}
