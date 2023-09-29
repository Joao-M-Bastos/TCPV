using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [SerializeField] Animator[] charactersAnimator;
    Rigidbody playerRB;

    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    public void DoActionBasedOnCode(int actionCode)
    {
        switch (actionCode)
        {
            case 1:
                playerRB.AddForce(this.transform.right * 10,ForceMode.Impulse);
                break;
            case 2:
                PlayAnimation("Attack");
                break;
        }
    }

    public void PlayMistakeAnimation()
    {
        PlayAnimation("Errou");
    }

    public void PlayMarchAnimation()
    {
        PlayAnimation("Marchar");
    }

    public void ResetMarchar()
    {
        foreach (Animator a in charactersAnimator)
        {
            a.ResetTrigger("Marchar");
        }
    }

    private void PlayAnimation(string code)
    {
        foreach (Animator a in charactersAnimator)
        {
            a.SetTrigger(code);
        }
    }
}
