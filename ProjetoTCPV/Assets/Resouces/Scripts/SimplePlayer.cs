using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    
    [SerializeField] PersonagenDaBateria[] charactersScripts;
    [SerializeField] ManagerScrpt gameManager;
    [SerializeField] float speed;
    Rigidbody playerRB;

    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();

        foreach (PersonagenDaBateria a in charactersScripts)
        {
            a.SetVelocidadeDeMarcha(gameManager.GetBPM() / 60);
        }
    }

    public void DoActionBasedOnCode(int actionCode)
    {
        switch (actionCode)
        {
            case 1:
                playerRB.AddForce(this.transform.right * speed,ForceMode.Impulse);
                break;
            case 2:
                PlayAnimation("Attack");
                CharactersAttack();
                break;
            case 3:
                playerRB.AddForce(-this.transform.right * speed, ForceMode.Impulse);
                break;
            case 4:
                PlayAnimation("Defence");
                break;
        }
    }

    #region Animation

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
        foreach (PersonagenDaBateria a in charactersScripts)
        {
            a.ResetAnimationsTrigger();
        }
    }

    private void PlayAnimation(string code)
    {
        foreach (PersonagenDaBateria a in charactersScripts)
        {
            a.PlayAnimation(code);
        }
    }

    #endregion

    #region Combate

    public void CharactersAttack()
    {
        foreach(PersonagenDaBateria pb in charactersScripts)
        {
            pb.Attack();
        }
    }

    #endregion
}
