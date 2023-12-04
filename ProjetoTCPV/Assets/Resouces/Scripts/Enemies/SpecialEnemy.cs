using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    public static int bateriaCount;
    
    public GameObject bateria;
    public GameObject enemyPrefab;
    GameObject newBateriaModel;

    void Start()
    {
        if (bateriaCount == 0)
            bateriaCount++;
    }

    void Update()
    {
        if (gameObject.tag == "Ally")
        {
            bateriaCount++;
            newBateriaModel = Instantiate(enemyPrefab, bateria.transform.position, bateria.transform.rotation);
            var pos = newBateriaModel.transform.position;
            pos.x -= bateriaCount;
            newBateriaModel.transform.position = pos;
            newBateriaModel.tag = "BateriaModel";
            
            Destroy(gameObject);
        }
    }
}
