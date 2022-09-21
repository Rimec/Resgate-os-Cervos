using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicle : MonoBehaviour
{
    private float time = 0.0f;
    [SerializeField] private float maxTime = 3.0f;
    [SerializeField] private Transform initialTransform;
    private void Start(){
        initialTransform = transform;
        GameManager.instance.SetAmountOfDeerInGame(GameObject.FindGameObjectsWithTag("Deer").Length);
    }
    private void Update()
    {
        if (isTurned() || Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.RemoveLife(1);
            ResetVehicle();
        }
    }

    private bool isTurned(){
        bool turned = false;
        if ((Vector3.Dot(transform.up, Vector3.down) > 0))
        {
            time+= Time.deltaTime;
            if (time >= maxTime)
            {
                turned = true;
                time = 0.0f;
            }
        }
        return turned;
    }

    private void ResetVehicle(){
        transform.position = initialTransform.position;
        transform.rotation = initialTransform.rotation;
    }

}
