using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : Wheel
{
    [SerializeField] bool hasSteerAngle;
    [SerializeField] bool hasTorque;
    [SerializeField] bool hasBrake;
    void FixedUpdate()
    {
        if (hasTorque)
        {
            float t = Input.GetAxis("Vertical") * GetTorque;
            this.gameObject.GetComponent<WheelCollider>().motorTorque = t;
        }
        if (hasSteerAngle)
        {
            float sA = Input.GetAxis("Horizontal") * GetSteerAngle;
            this.gameObject.GetComponent<WheelCollider>().steerAngle = sA;
        }
        if (hasBrake)
        {
            float b = Input.GetKey(KeyCode.Space) ? GetBrakeTorque : 0;
            b = (Input.GetAxis("Vertical") == 0) ? GetBrakeTorque : 0;
            this.GetComponent<WheelCollider>().brakeTorque = b;
        }
    }
}
