using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody playerRB;

    private void Awake()
    {
        playerAnimator = this.gameObject.GetComponent<Animator>();
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    public void DoActionBasedOnCode(int actionCode)
    {
        switch (actionCode)
        {
            case 1:
                playerRB.AddForce(this.transform.forward * 10,ForceMode.Impulse);
                break;
            case 2:
                playerAnimator.SetTrigger("Attack");
                break;
        }
    }
}
