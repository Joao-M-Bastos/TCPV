using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictator : MonoBehaviour
{
    #region Combat

    [SerializeField] int viewDistance;

    [SerializeField] GameObject[] enemyToSpawn;

    int fase;

    #endregion

    [SerializeField] Animator dictorAnimator;

    [SerializeField] Transform targetPlace;
    [SerializeField] Transform spawnPlace;

    float spawnCooldownBase;
    float spawnCooldown;

    SimplePlayer player;
    [SerializeField] ManagerScrpt manager;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayer>();
    }

    private void Start()
    {
        spawnCooldownBase = ManagerScrpt.GetBPS() * 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCooldown >= 0)
        {
            spawnCooldown -= Time.deltaTime;
            return;
        }
        
        switch (fase)
        {
            case 0:
                VerifyDistance(viewDistance * 1.5f);
                break;
            case 1:
                SpawnMinion();
                spawnCooldown = spawnCooldownBase;
                VerifyDistance(viewDistance);
                break;
            case 2:
                SpawnMinion();
                spawnCooldown = spawnCooldownBase / 2;
                VerifyDistance(viewDistance / 2);
                break;
            case 3:
                SpawnMinion();
                spawnCooldown = spawnCooldownBase / 3;
                VerifyAllyCount();
                break;
            case 4:
                manager.GameOver(true);
                break;
        }
    }

    private void VerifyAllyCount()
    {
        if(player.AllyCount > 10)
        {
            fase++;
        }
    }

    private void VerifyDistance(float distance)
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < distance)
        {
            fase++;
        }
    }



    private void SpawnMinion()
    {
        dictorAnimator.SetTrigger("Ataquem");
        int random = Random.Range(0, 2);
        GameObject enemy = Instantiate(enemyToSpawn[random], spawnPlace.position, enemyToSpawn[random].transform.rotation);
        enemy.GetComponent<StreetEnemy>().isMinion = 100;
        enemy.GetComponent<Enemy>().SetTarget(targetPlace);
    }
}
