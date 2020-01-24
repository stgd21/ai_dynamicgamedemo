using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation
{
    public Kinematic character;

    //List of potential targets
    public List<Kinematic> targets = new List<Kinematic>();

    //Threshold to take action
    float threshold = 3f;

    //Constant coefficient of decay for inverse square law
    float decayCoefficient = -6f;

    float maxAcceleration = 5f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //Loop through each target
        for (int i = 0; i < targets.Count; i++)
        {
            //Check if target is close
            Vector3 direction = targets[i].transform.position - character.transform.position;
            float distance = direction.magnitude;

            if (distance < threshold)
            {
                //Calculate strength of repulsion using inverse square law
                float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                //Add acceleration
                direction.Normalize();
                result.linear += strength * direction;
            }
        }
        return result;
    }
}

