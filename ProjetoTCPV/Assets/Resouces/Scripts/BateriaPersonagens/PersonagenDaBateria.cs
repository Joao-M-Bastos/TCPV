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
        characterAnimator.ResetTrigger("Errou");
        characterAnimator.ResetTrigger("Attack");
        characterAnimator.ResetTrigger("Defence");
    }

    public void PlayAnimation(string animationCode)
    {
        characterAnimator.SetTrigger(animationCode);
    }

    #endregion

    public void Attack(Vector3 bulletTarget) {
        GameObject bullet = Instantiate(projectile, projectilePointOfInstanciation.position, projectilePointOfInstanciation.rotation);
        PrincipalBullet bulletScpt = bullet.GetComponent<PrincipalBullet>();

        bulletScpt.SetTarget(bulletTarget);
    }
}
