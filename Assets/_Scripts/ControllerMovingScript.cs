using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovingScript : MonoBehaviour
{

    private Vector3 movement;
    private float x;
    private float z;
    private float speed;
    private Rigidbody rigidBody;
    [HideInInspector]public Transform playerPos;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        speed = 10;
    }

    void Update ()
    {

        if (Input.GetJoystickNames().Length > 0)
        {
            x = Input.GetAxisRaw("LeftStickX");
            z = Input.GetAxisRaw("LeftStickY");
        }
        else
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetButtonDown("Square"))
	    {
	        Debug.Log("You pressed Square");
	    }
        if (Input.GetButtonDown("X"))
        {
            Debug.Log("You pressed X");
        }
        if (Input.GetButtonDown("Circle"))
        {
            Debug.Log("You pressed Circle");
        }
        if (Input.GetButtonDown("Triangle"))
        {
            Debug.Log("You pressed Triangle");
        }
        movement = transform.forward.normalized * z;
    }

    void FixedUpdate()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + velocity);
    }
}
