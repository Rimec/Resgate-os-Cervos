using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float runningRange, scareRange;
    [SerializeField] private bool playerInRunningRange, playerInScareRange;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private DeerStrategy deerStrategy;
    [SerializeField] private float runPointRange;

    private DeerIdle idle = new DeerIdle();
    private float time = 0.0f;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody myRigidBody;
    [SerializeField] private float speed;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        playerInScareRange = Physics.CheckSphere(transform.position, scareRange, whatIsPlayer);
        playerInRunningRange = Physics.CheckSphere(transform.position, runningRange, whatIsPlayer);
        deerStrategy = (playerInScareRange) ? new DeerScared() : idle;

        if (playerInRunningRange)
        {
            deerStrategy = new DeerRunning();
            Run();
        }
        if (deerStrategy == idle)
        {
            time += Time.fixedDeltaTime;
            if (time >= 5.0f)
            {
                deerStrategy?.Action(animator);
                time = 0.0f;
            }
        }
        else
        {
            deerStrategy?.Action(animator);
        }
        if (CollidedWithPlayer())
        {
            Rescued();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, runningRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, scareRange);
    }
    public void Run()
    {
        Vector3 direction = transform.position - player.position;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
        myRigidBody.MovePosition(myRigidBody.position + direction.normalized * speed * Time.deltaTime);
    }
    public bool CollidedWithPlayer(){
        bool collided = false;
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= 2.0f)
        {
            collided = true;
        }
        return collided;
    }
    public void Rescued(){
        Destroy(this.gameObject);
    }
}
