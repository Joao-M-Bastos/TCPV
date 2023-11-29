using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionScrpt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator playerAnimator = other.gameObject.GetComponent<Animator>();
            playerAnimator.enabled = true;

            //playerAnimator.SetTrigger("EnterBossFight");

            StartCoroutine(turnAnimatorOff(playerAnimator));
        }
    }

    IEnumerator turnAnimatorOff(Animator playerAnimator)
    {
        yield return new WaitForSeconds(3.5f);
        playerAnimator.enabled = false;

    }
}
