using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed, lifeSpam;
    [SerializeField] int damage;

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
        SimplePlayer player;
        if (other.gameObject.TryGetComponent<SimplePlayer>(out player))
        {
            player.GotHit(damage);
            Destroy(gameObject);
        }
    }

    internal void SetTarget(Vector3 bulletTarget)
    {
        target = bulletTarget;
        this.transform.LookAt(target);
    }
}
