using System;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private float torque = 2000f;
    private float steerAngle = 30.0f;
    private float brakeTorque = 4000.0f;
    public float GetTorque => torque;
    public float GetSteerAngle => steerAngle;
    public float GetBrakeTorque => brakeTorque;
}
