using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetEnemy : MonoBehaviour, Enemy
{
    #region CombatStatus

    [SerializeField] float life;
    [SerializeField] int damage;
    [SerializeField] int viewDistance;

    [SerializeField] GameObject enemyProjectile;

    float attackCooldown;

    #endregion

    SimplePlayer player;
    SimpleAlly simpleAlly;



    private void Awake()
    {
        simpleAlly = gameObject.GetComponent<SimpleAlly>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayer>();

        attackCooldown = ManagerScrpt.GetBPS() * 4;
    }

    private void Update()
    {
        Attack();
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

    public void Attack()
    {
        if (IsPlayerNear(viewDistance))
        {

            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
                return;
            }

            attackCooldown = ManagerScrpt.GetBPS() * 4;


            GameObject projectileInstace = Instantiate(enemyProjectile, this.transform.position + this.transform.up, enemyProjectile.transform.rotation);

            EnemyBullet bulletScpt = projectileInstace.GetComponent<EnemyBullet>();

            bulletScpt.SetTarget(player.transform.position);

            
        }else if(IsPlayerNear(viewDistance * 1.5f))
        {
            //transform.LookAt(player.transform);
            this.transform.position += new Vector3(-1,0,0) * Time.deltaTime;
        }
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
