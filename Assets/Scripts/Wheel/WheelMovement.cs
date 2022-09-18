using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : Wheel
{
    [SerializeField] bool hasSteerAngle;
    void FixedUpdate()
    {
        float t = Input.GetAxis("Vertical") * GetTorque;
        if (hasSteerAngle)
        {
            float sA = Input.GetAxis("Horizontal") * GetSteerAngle;
            this.gameObject.GetComponent<WheelCollider>().steerAngle = sA;
        }
        float b = Input.GetKey(KeyCode.Space) ? GetBrakeTorque : 0;
        b = (Input.GetAxis("Vertical") == 0) ? GetBrakeTorque : 0;
        this.gameObject.GetComponent<WheelCollider>().motorTorque = t;
        this.GetComponent<WheelCollider>().brakeTorque = b;
    }
}
