using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCspawner : MonoBehaviour
{
    [SerializeField] GameObject[] NPCs;
    [SerializeField] Transform targetPlace;

    [SerializeField] bool isDirectionRight;

    float cooldown;

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            GameObject NPC = Instantiate(NPCs[Random.Range(0, 3)], this.transform);
            NPC.GetComponent<NPC>().directionRight = isDirectionRight;
            NPC.GetComponent<NPC>().SetTarget(targetPlace);

            cooldown = 20 + Random.Range(5, 15);
        }
        cooldown -= Time.deltaTime;
    }
}
