using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive
{
    public Kinematic character;
    public Kinematic target;

    float maxAcceleration = 20f;
    float maxSpeed = 16f;

    //Radius for arriving at target
    float targetRadius = 0.5f;

    //Radius for beginning to slow down
    float slowRadius = 8f;

    //Time over which to achieve target speed
    float timeToTarget = 0.1f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        float targetSpeed;

        //Get direction to target
        Vector3 direction = target.transform.position - character.transform.position;
        float distance = direction.magnitude;

        //Check if we are there, return no steering
        if (distance < targetRadius)
        {
            character.linearVelocity = Vector3.zero;
            character.angularVelocity = 0f;
            return null;
        }
            

        //If we are outside slowRadius, move at max speed
        if (distance > slowRadius)
            targetSpeed = maxSpeed;
        //Otherwise calculate a scaled speed
        else
            targetSpeed = maxSpeed * distance / slowRadius;

        //Target velocity combines speed and direction
        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        //Acceleration tries to get to target velocity
        result.linear = targetVelocity - character.linearVelocity;
        result.linear /= timeToTarget;

        //Check if acceleration is too fast
        if (result.linear.magnitude > maxAcceleration)
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }

        result.angular = 0;
        return result;
   
    }
}
