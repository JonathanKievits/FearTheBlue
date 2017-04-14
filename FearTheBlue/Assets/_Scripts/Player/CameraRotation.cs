using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    [Range(1, 5)][SerializeField] private float turnSpeed;

    void Update()
    {
        var x = Input.GetAxis(Controller.RightStickX);

        transform.Rotate(0,x * turnSpeed,0);
    }
}
