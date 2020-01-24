﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align
{
    public Kinematic character;
    public Kinematic target;

    float maxAngularAcceleration = 20f;
    float maxRotation = 30f;

    //Radius for arriving at target
    float targetRadius = 1f;

    //Radius for beginning to slow down
    float slowRadius = 30f;

    //Time over which to acheive target speed
    float timeToTarget = 0.1f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        float targetRotation;

        //Get naive direction to target and map result to (-pi, pi) interval
        float rotation = Mathf.DeltaAngle(
            character.transform.rotation.eulerAngles.y,
            target.transform.rotation.eulerAngles.y);
        float rotationSize = Mathf.Abs(rotation);

        //Check if we are there, return no steering
        if (rotationSize < targetRadius)
        {
            character.angularVelocity = 0f;
            return null;
        }
            

        //If we are outside slowRadius, use maximum rotation
        if (rotationSize > slowRadius)
            targetRotation = maxRotation;
        //Otherwise calculate scaled rotation
        else
            targetRotation = maxRotation * rotationSize / slowRadius;

        //The final target rotation combines speed (already in variable) and direction
        targetRotation *= rotation / rotationSize;

        //Acceleration tries to get to the target rotation
        result.angular = targetRotation - character.angularVelocity;
        result.angular /= timeToTarget;

        //Check if acceleration is too great
        float angularAcceleration = Mathf.Abs(result.angular);
        if (angularAcceleration > maxAngularAcceleration)
        {
            result.angular /= angularAcceleration;
            result.angular *= maxAngularAcceleration;
        }

        result.linear = Vector3.zero;
        return result;
    }

}
