using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalBullet : MonoBehaviour
{
    [SerializeField] float speed, lifeSpam;
    [SerializeField] float damage;

    Vector3 target;

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
        Enemy enemy;
        if (other.gameObject.TryGetComponent(out enemy)){
            
            enemy.GotHit(damage);
            Destroy(gameObject);
        }
    }

    internal void SetValues(Vector3 bulletTarget, float _damage)
    {
        target = bulletTarget;

        damage += _damage;

        this.transform.LookAt(target);
    }
}
