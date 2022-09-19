using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    [SerializeField] private bool walkPointSet = false;
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private float speed;
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-10.0f, 10.0f);
        float randomX = Random.Range(-10.0f, 10.0f);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        walkPointSet = true;
    }
    void Run(Vector3 _walkPoint){
        Vector3 direction = walkPoint - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }
    void FixedUpdate()
    {
        Patroling();
    }

    void Patroling(){
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) Run(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1.0f) {
            walkPointSet = false;
        }
    }
}
