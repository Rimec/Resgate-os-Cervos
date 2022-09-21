using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicle : MonoBehaviour
{
    private float time = 0.0f;
    private float maxTime = 3.0f;
    void Update()
    {
        if (isTurned())
        {
            SceneManager.LoadScene("Game");
            GameManager.instance.RemoveLife(1);
        }
    }

    bool isTurned(){
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

}
