using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public WheelCollider[] rodas;
    public Transform[] rodasShape;
    [SerializeField] private float torque = 1000f;
    [SerializeField] private float volante = 30.0f;
    [SerializeField] private float freio = 2000.0f;
    void FixedUpdate()
    {
        float t = Input.GetAxis("Vertical") * torque;
        float v = Input.GetAxis("Horizontal") * volante;
        float f = Input.GetKey(KeyCode.Space) ? freio : 0;
        f = (Input.GetAxis("Vertical") == 0) ? freio : 0;

        Vector3 posicao;
        Quaternion rotacao;

        for (int i = 0; i < rodas.Length; i++)
        {
            rodas[i].GetWorldPose(out posicao, out rotacao);
            rodasShape[i].position = posicao;
            rodasShape[i].rotation = rotacao;
        }
        for (int i = 0; i < 2; i++)
        {
            rodas[i].motorTorque = t;
            rodas[i].steerAngle = v;
        }
        for (int i = 0; i < rodas.Length; i++)
        {
            rodas[i].brakeTorque = f;
        }
    }
}
