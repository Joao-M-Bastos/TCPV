using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metro : MonoBehaviour
{
    [SerializeField] float speed, lifeSpam;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;

        if (lifeSpam < 0)
            Destroy(gameObject);
        else
            lifeSpam -= Time.deltaTime;
    }
}
