using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] int life;
    SimpleAlly simpleAlly;

    private void Awake()
    {
        simpleAlly = gameObject.GetComponent<SimpleAlly>();
    }

    public void GotHit(int value)
    {
        life -= value;
        if (life <= 0)
            ChangeEnemyToAlly();
    }

    public int GetLife()
    {
        return life;
    }

    private void ChangeEnemyToAlly()
    {
        simpleAlly.ChangeToAlly();
        Destroy(this);
    }
}
