using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    
    [SerializeField] PersonagenDaBateria[] charactersScripts;
    [SerializeField] ManagerScrpt gameManager;
    [SerializeField] float speed, viewDistance;

    Vector3 bulletTarget;

    Rigidbody playerRB;

    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }


    private void Start()
    {
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
        FindCloseEnemy();
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
    private void FindCloseEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Vector3 closestEnemy = Vector3.zero;
        float closestEnemyValue = 100;

        for(int i = 0; i < enemies.Length; i++)
        {
            float distacia = Vector3.Distance(this.transform.position, enemies[i].transform.position);
            
            if(distacia < viewDistance && distacia < closestEnemyValue)
            {
                closestEnemy = enemies[i].transform.position;
                closestEnemyValue = distacia;
            }
        }

        bulletTarget = closestEnemy;
    }

    public void CharactersAttack()
    {
        if (bulletTarget != Vector3.zero)
        {
            foreach (PersonagenDaBateria pb in charactersScripts)
            {
                pb.Attack(bulletTarget);
            }
        }
    }

    #endregion
}
