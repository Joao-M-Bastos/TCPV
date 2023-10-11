using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalBullet : MonoBehaviour
{
    [SerializeField] float speed, lifeSpam;
    [SerializeField] int damage;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position += transform.forward * speed * Time.deltaTime;

        if (lifeSpam < 0)
            Destroy(gameObject);
        else
            lifeSpam -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        SimpleEnemy enemy;
        if (other.gameObject.TryGetComponent<SimpleEnemy>(out enemy)){
            
            enemy.GotHit(damage);
            Destroy(gameObject);
        }
    }

    internal void SetTarget(Vector3 bulletTarget)
    {
        target = bulletTarget;
    }
}
