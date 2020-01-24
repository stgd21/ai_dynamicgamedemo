using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    public Kinematic target;

    public SteeringOutput getSteering()
    {
        //Calculate target to delegate to align
        Vector3 direction = target.transform.position - character.transform.position;
        if (direction.magnitude == 0)
            return null;

        base.target = target;
        float angle = Mathf.Atan2(direction.x, direction.z);
        angle *= Mathf.Rad2Deg;
        base.target.transform.eulerAngles = new Vector3(0, angle, 0);
        return base.getSteering();
    }
}
