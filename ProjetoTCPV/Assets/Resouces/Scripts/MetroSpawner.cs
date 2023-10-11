using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroSpawner : MonoBehaviour
{
    [SerializeField] GameObject metro;

    [SerializeField] float cooldownBase;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = cooldownBase;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            cooldown = cooldownBase;
            Instantiate(metro, transform);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
