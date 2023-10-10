using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagenDaBateria : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectilePointOfInstanciation;

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
    }

    public void PlayAnimation(string animationCode)
    {
        characterAnimator.SetTrigger(animationCode);
    }

    #endregion

    public void Attack() {
        Instantiate(projectile, projectilePointOfInstanciation.position, projectilePointOfInstanciation.rotation);
    }
}
