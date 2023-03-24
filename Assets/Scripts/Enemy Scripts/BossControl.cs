using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    private Transform playerTarget;
    private BossStateChecker bossStateChecker;
    private NavMeshAgent navAgent;
    private Animator anim;

    private bool finishedAttacking = true;
    private float currentAttackTýme;
    private float waitAttackTime = 1f;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        bossStateChecker = GetComponent<BossStateChecker>();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        
        if(finishedAttacking)
        {
            GetStateControl();
        }
        else
        {
            anim.SetInteger("Atk", 0);
            if(!anim.IsInTransition(0)&& anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttacking = true;
            }
        }
    }

    void GetStateControl()
    {
        if(bossStateChecker.BossState == Boss_State.DEATH)
        {
            navAgent.isStopped = true;

            anim.SetBool("Death", true);
            Destroy(gameObject, 4f);
        }
        else
        {
            if(bossStateChecker.BossState == Boss_State.PAUSE)
            {
                navAgent.isStopped = false;
                anim.SetBool("Run", true);
                navAgent.SetDestination(playerTarget.position);
            }
            else if (bossStateChecker.BossState == Boss_State.ATTACK)
            {
                anim.SetBool("Run", false);
                Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition),5f * Time.deltaTime);

                if(currentAttackTýme >= waitAttackTime)
                {
                    int AtkRange = Random.Range(3, 5);
                    anim.SetInteger("Atk", AtkRange);

                    currentAttackTýme = 0f;
                    finishedAttacking = false;
                } 
                else
                {
                    anim.SetInteger("Atk", 0);
                    currentAttackTýme += Time.deltaTime;
                }

            }
            else
            {
                anim.SetBool("Run", false);
                navAgent.isStopped = true;
            }
        } 
    }


}
