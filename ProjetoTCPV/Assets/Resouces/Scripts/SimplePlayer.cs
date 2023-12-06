using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject shildPrefab;
    GameObject shild;

    [SerializeField] Transform projectilePointOfInstanciation;

    [SerializeField] PersonagenDaBateria[] charactersScripts;

    [SerializeField] GameObject newMember;

    [SerializeField] ParticleSystem attackEffect;
    [SerializeField] ManagerScrpt gameManager;

    [SerializeField] int life;
    
    int allyCount;
    public int AllyCount => allyCount;

    int speed, viewDistance, damage, defence;
    bool isDefending;

    bool passBlock;

    Rigidbody playerRB;

    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    public void AddAlly()
    {
        allyCount++;
    }

    public void SetNewMemberToVisible()
    {
        newMember.SetActive(true);
    }

    private void Start()
    {
        foreach (PersonagenDaBateria a in charactersScripts)
        {
            

            a.SetVelocidadeDeMarcha(ManagerScrpt.GetBPS());

            speed += a.Speed;
            viewDistance += a.ViewDistance;
            life += a.Life;
            damage += a.Damage;
            defence += a.Defence;
        }

        charactersScripts[2].gameObject.SetActive(false);
    }

    public void DoActionBasedOnCode(int actionCode)
    {
        if (actionCode == 2)
            BreakShild();

        if (passBlock)
            passBlock = false;
        else
            BreakShild();

        switch (actionCode)
        {
            case 1:
                PlayAnimation("Andar");
                ApplyImpulse(this.transform.right, speed);
                break;
            case 2:
                PlayAnimation("Acertou");
                Attack();
                break;
            case 3:
                PlayAnimation("Defence");
                passBlock = true;
                SetShild();
                break;
            case 4:
                PlayAnimation("Andar");
                ApplyImpulse(-this.transform.right, speed);
                break;
        }
    }

    private void BreakShild()
    {
        isDefending = false;
        Destroy(shild);
    }

    private void SetShild()
    {
        isDefending = true;
        shild = Instantiate(shildPrefab, this.transform);
    }

    public void Die()
    {
        gameManager.GameOver(false);

        foreach (PersonagenDaBateria p in charactersScripts)
        {
            if (!p.isActiveAndEnabled)
                break;
            p.gameObject.SetActive(false);

        }

    }

    #region Animation

    public void PlayMistakeAnimation()
    {
        PlayAnimation("Errou");
        isDefending = false;
    }
    
    public void PlayWhistleAnimation()
    {
        charactersScripts[0].PlayAnimation("Apitar");
    }

    public void PlayMarchAnimation()
    {
        PlayAnimation("Marchar");
    }

    public void ResetMarchar()
    {
        foreach (PersonagenDaBateria p in charactersScripts)
        {
            if (!p.isActiveAndEnabled)
                break;

            p.ResetAnimationsTrigger();
        }
    }

    private void PlayAnimation(string code)
    {
        foreach (PersonagenDaBateria p in charactersScripts)
        {
            if (!p.isActiveAndEnabled)
                break;
            p.PlayAnimation(code);
        }
    }

    public bool IsWrongPlaying()
    {
        foreach (PersonagenDaBateria p in charactersScripts)
        {
            if (!p.isActiveAndEnabled)
                break;

            if (p.IsWrongAnimationPlaying())
                return true;
        }
        
        return false;
    }

    #endregion

    #region Movimentation

    public void ApplyImpulse(Vector3 direction, float force)
    {
        if (IsEnemyNear(3))
            force = 0;
        else if (IsEnemyNear(-1))
            force /= 2;

        playerRB.AddForce(direction * force, ForceMode.Impulse);
    }

    #endregion

    #region Combate

    public void GotHit(int value)
    {
        int temp = value;

        if (isDefending)
            temp -= defence;

        if(temp > 0)
            life -= temp;

        if (life <= 0)
            Die();
    }

    public bool IsEnemyNear(float lessView)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            float distacia = Vector3.Distance(this.transform.position, enemies[i].transform.position);

            if (distacia < (viewDistance - lessView))
            {
                return true;
            }
        }

        return false;
    }

    public void Attack()
    {
        GameObject bullet = Instantiate(projectile, projectilePointOfInstanciation.position, projectilePointOfInstanciation.rotation);
        PrincipalBullet bulletScpt = bullet.GetComponent<PrincipalBullet>();


        bulletScpt.SetValues(projectilePointOfInstanciation.transform.position + Vector3.right, damage);

        attackEffect.Play();
    }
    #endregion
}
