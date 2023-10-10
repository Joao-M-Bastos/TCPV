using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaBulelt : MonoBehaviour
{
    [SerializeField] float speed, lifeSpam;
    [SerializeField] int damage;
    // Start is called before the first frame update
    void Start()
    {

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
        if (other.gameObject.TryGetComponent<SimpleEnemy>(out enemy)) { 
            enemy.GotHit(damage);
            Destroy(gameObject);
        }
    }
}
