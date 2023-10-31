using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleAlly : MonoBehaviour
{
    [SerializeField] Transform targetPlace;
    [SerializeField] float allowedDistanceFromTarget, speed, maxSpeed, maxSpeedRunningToTarget;

    Rigidbody allyRB;

    bool isStillEnemy;

    // Start is called before the first frame update
    void Start()
    {
        allyRB = gameObject.GetComponent<Rigidbody>();
        isStillEnemy = true;
    }

    public void ChangeToAlly()
    {
        isStillEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStillEnemy)
            return;

        if(isFarFromTarget(this.transform.position, targetPlace.transform.position) && canWalk(maxSpeedRunningToTarget))
            RunToTarget();
        

        if (canWalk(maxSpeed))
            WalkRandomly();

        Friction();
    }

    private void Friction()
    {
        allyRB.velocity *= 0.95f;
    }

    private void WalkRandomly()
    {
        float x = Random.Range(-1f,1f);
        float z = Random.Range(-1f, 1f);

        Vector3 direction = new Vector3(x, 0, z).normalized;

        WalkToDirection(direction);
    }

    private void RunToTarget()
    {
        Vector3 direction = (targetPlace.position - transform.position).normalized;
        WalkToDirection(direction);
    }

    private void WalkToDirection(Vector3 direction)
    {
        transform.LookAt(this.transform.position + direction);

        allyRB.AddForce(this.transform.forward * speed, ForceMode.VelocityChange);
    }

    private bool isFarFromTarget(Vector3 pos1, Vector3 pos2)
    {
        return Vector3.Distance(pos1, pos2) > allowedDistanceFromTarget;
    }

    private bool canWalk(float maxInQuestion)
    {
        return GetCurrentSpeed() < maxInQuestion;
    }

    private float GetCurrentSpeed()
    {
        Vector3 velocity = allyRB.velocity;

        float speed = Math.Abs(velocity.x) + Math.Abs(velocity.z);

        return speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            allyRB.AddForce(this.transform.right * speed /2, ForceMode.VelocityChange);
        }
    }
}
