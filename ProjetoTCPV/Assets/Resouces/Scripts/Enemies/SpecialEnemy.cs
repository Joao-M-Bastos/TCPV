using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    public GameObject bateria;
    public GameObject enemyPrefab;
    GameObject newBateriaModel;

    void Update()
    {
        if(gameObject.tag == "Ally")
        {
            Destroy(GameObject.FindGameObjectWithTag("BateriaModel"));
            newBateriaModel = Instantiate(enemyPrefab, bateria.transform.position, bateria.transform.rotation);
            newBateriaModel.tag = "BateriaModel";
            
            Destroy(gameObject);
        }
    }
}
