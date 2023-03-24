using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmonut = 10f;

    private Transform playerTargert;
    private Animator anim;
    private bool finishedAttack = true;
    private float damageDistance = 2f;


    private PlayerHealth playerHealth;


    private void Awake()
    {
        playerTargert = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        playerHealth = playerTargert.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if(finishedAttack)
        {
            DeadDamage(CheeckIfAttacking());
        }

        else
        {
            if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttack = true;
            }
        }
    }


    bool CheeckIfAttacking()
    {
        bool isAttacking = false;

        if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") ||anim.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= .5f)
            {
                isAttacking = true;
                finishedAttack = false;
            }
        }

        return isAttacking;
    }


    void DeadDamage(bool isAttacking)
    {
        if(isAttacking)
        {
            if(Vector3.Distance(transform.position,playerTargert.position) <= damageDistance)
            {
                playerHealth.TakeDamage(damageAmonut);

            }
        }
    }


}
