using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StreetEnemy : MonoBehaviour, Enemy
{
    #region CombatStatus

    [SerializeField] float life;
    [SerializeField] int damage;
    [SerializeField] int viewDistance;

    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Animator enemyAnimator;

    float attackCooldown;

    #endregion

    SimplePlayer player;
    SimpleAlly simpleAlly;

    int directionX;
    float changeDirectionCooldown;

    public int isMinion = 1;

    private void Awake()
    {
        simpleAlly = gameObject.GetComponent<SimpleAlly>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayer>();
        enemyAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        attackCooldown = ManagerScrpt.GetBPS() * 3f;
    }

    public void SetTarget(Transform target)
    {
        simpleAlly.targetPlace = target;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        Action();
    }

    #region Defesa/Vida
    public void GotHit(float value)
    {
        life -= value;
        if (life <= 0)
            ChangeEnemyToAlly();
    }

    public float GetLife()
    {
        return life;
    }
    #endregion

    #region Ataque

    public void Action()
    {
        if (IsPlayerNear(viewDistance))
            Attack();

        else if(IsPlayerNear(viewDistance * 1.5f * isMinion))
        {
            this.transform.position += new Vector3(-3f,0,0) * Time.deltaTime;
        }
        else
        {
            if(changeDirectionCooldown <= 0)
            {
                changeDirectionCooldown = 3 + Random.Range(0,2);
                directionX = Random.Range(0, 3) - 1;
            }
            changeDirectionCooldown -= Time.deltaTime;
            this.transform.position += new Vector3(directionX, 0, 0) * Time.deltaTime * 1f;
        }
    }

    private void Attack()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            return;
        }

        enemyAnimator.SetTrigger("Atacar");

        attackCooldown = ManagerScrpt.GetBPS() * 4;

        StartCoroutine(CreateBullet());
    }

    IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(1);

        GameObject projectileInstace = Instantiate(enemyProjectile, this.transform.position + (this.transform.up * 3), enemyProjectile.transform.rotation);

        EnemyBullet bulletScpt = projectileInstace.GetComponent<EnemyBullet>();

        bulletScpt.SetTarget(player.transform.position);
    }

    private bool IsPlayerNear(float distance)
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < distance)
            return true;

        return false;
    }



    #endregion

    private void ChangeEnemyToAlly()
    {
        simpleAlly.ChangeToAlly();
        this.gameObject.tag = "Ally";

        Destroy(this);
    }
}
