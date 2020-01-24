using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum steeringBehaviors {
    Simple,
    Seek,
    Flee,
    Arrive,
    Align,
    Face,
    LookWhereGoing,
    Separation
}

public class Kinematic : MonoBehaviour
{
    //position from gameobject's transform component
    //rotation from gameobject's transform component
    public Vector3 linearVelocity;
    public float angularVelocity; //In degrees
    public Kinematic target;

    public steeringBehaviors behavior;

    // Update is called once per frame
    void Update()
    {
        switch (behavior)
        {
            case steeringBehaviors.Simple:
                UpdatePositionRotation();
                break;
            case steeringBehaviors.Separation:
                SeparationBehavior();
                break;
            default:
                StandardBehavior();
                break;
        }
    }

    void UpdatePositionRotation()
    {
        //Update position and rotation
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angularVelocity * Time.deltaTime, 0);
        transform.eulerAngles += angularIncrement;
    }

    void StandardBehavior()
    {
        UpdatePositionRotation();

        switch (behavior)
        {
            case steeringBehaviors.Seek:
                Seek seek = new Seek();
                seek.character = this;
                seek.target = target;
                SteeringOutput seekSteering = seek.getSteering();
                if (seekSteering != null)
                {
                    linearVelocity += seekSteering.linear * Time.deltaTime;
                    angularVelocity += seekSteering.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Flee:
                Flee flee = new Flee();
                flee.character = this;
                flee.target = target;
                SteeringOutput fleeSteering = flee.getSteering();
                if (fleeSteering != null)
                {
                    linearVelocity += fleeSteering.linear * Time.deltaTime;
                    angularVelocity += fleeSteering.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Arrive:
                Arrive arrive = new Arrive();
                arrive.character = this;
                arrive.target = target;
                SteeringOutput arriveSteering = arrive.getSteering();
                if (arriveSteering != null)
                {
                    linearVelocity += arriveSteering.linear * Time.deltaTime;
                    angularVelocity += arriveSteering.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Align:
                Align align = new Align();
                align.character = this;
                align.target = target;
                SteeringOutput alignSteering = align.getSteering();
                if (alignSteering != null)
                {
                    linearVelocity += alignSteering.linear * Time.deltaTime;
                    angularVelocity += alignSteering.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Face:
                Face face = new Face();
                face.character = this;
                face.target = target;
                SteeringOutput faceSteering = face.getSteering();
                if (faceSteering != null)
                {
                    linearVelocity += faceSteering.linear * Time.deltaTime;
                    angularVelocity += faceSteering.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.LookWhereGoing:
                LookWhereGoing look = new LookWhereGoing();
                look.character = this;
                look.target = target;
                SteeringOutput lookSteering = look.getSteering();
                if (lookSteering != null)
                {
                    linearVelocity += lookSteering.linear * Time.deltaTime;
                    angularVelocity += lookSteering.angular * Time.deltaTime;
                }
                break;
        }

    }

    void SeparationBehavior()
    {
        UpdatePositionRotation();

        Separation separation = new Separation();
        separation.character = this;
        separation.targets.Add(target);
        SteeringOutput separationSteering = separation.getSteering();
        if (separationSteering != null)
        {
            linearVelocity += separationSteering.linear * Time.deltaTime;
            angularVelocity += separationSteering.angular * Time.deltaTime;
        }
    }

    public void SetSeek()
    {
        behavior = steeringBehaviors.Seek;
    }
    public void SetFlee()
    {
        behavior = steeringBehaviors.Flee;
    }
    public void SetArrive()
    {
        behavior = steeringBehaviors.Arrive;
    }
    public void SetAlign()
    {
        behavior = steeringBehaviors.Align;
    }
    public void SetFace()
    {
        behavior = steeringBehaviors.Face;
    }
    public void SetLook()
    {
        behavior = steeringBehaviors.LookWhereGoing;
    }
}
