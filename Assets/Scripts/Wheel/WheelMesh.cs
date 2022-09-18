using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMesh : Wheel
{
    [SerializeField] private WheelCollider wheelCollider;
    void FixedUpdate()
    {
        Vector3 _position;
        Quaternion _rotation;
        wheelCollider.GetWorldPose(out _position, out _rotation);
        this.transform.position = _position;
        this.transform.rotation = _rotation;
    }
}
