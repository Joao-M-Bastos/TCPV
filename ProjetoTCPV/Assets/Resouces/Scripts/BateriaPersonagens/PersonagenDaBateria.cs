using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagenDaBateria : MonoBehaviour
{
    [SerializeField] int speed, viewDistance, life, damage, defence;
    public int Speed => speed;
    public int ViewDistance => viewDistance;
    public int Life => life;
    public int Damage => damage;

    public int Defence => defence;

    [SerializeField] Animator characterAnimator;

    private void Awake()
    {
        characterAnimator = GetComponent<Animator>();
    }

    #region Animator

    public void SetVelocidadeDeMarcha(float BPM)
    {
        characterAnimator.SetFloat("VelocidadeDeMarcha", BPM);
    }

    public void ResetAnimationsTrigger()
    {
        characterAnimator.ResetTrigger("Marchar");
        characterAnimator.ResetTrigger("Errou");
        characterAnimator.ResetTrigger("Attack");
        characterAnimator.ResetTrigger("Defence");
    }

    public void PlayAnimation(string animationCode)
    {
        characterAnimator.SetTrigger(animationCode);
    }

    public bool IsWrongAnimationPlaying()
    {
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Errou"))
        {
            return true;
        }

        return false;
    }

    #endregion
}
