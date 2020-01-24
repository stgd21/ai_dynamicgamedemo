using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;
    private GameObject camera;
    private float offset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");
        offset = camera.transform.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerBody.AddForce(0, 0, -10, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerBody.AddForce(0, 0, 10, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerBody.AddForce(10, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerBody.AddForce(-10, 0, 0, ForceMode.VelocityChange);
        }
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, playerBody.transform.position.z + offset);
    }
}
