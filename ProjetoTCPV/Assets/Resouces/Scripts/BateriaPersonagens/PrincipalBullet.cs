using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalBullet : MonoBehaviour
{
    [SerializeField]float speed, lifeSpam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if(lifeSpam < 0)
            Destroy(gameObject);
        else
            lifeSpam -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Acertou");
            Destroy(gameObject);
        }
    }
}
