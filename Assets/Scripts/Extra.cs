using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra : MonoBehaviour
{
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    // private void OnCollisionExit(Collision other) {
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //     {
    //         rb.constraints = RigidbodyConstraints.FreezeAll;
    //     }
    // }

}
