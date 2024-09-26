using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private MoveForward moveForward;
    private PlayerDetected playerDetected;
    private Animator animator;
    private EnemyDeath enemyDeath;

    void Start()
    {
        moveForward = GetComponent<MoveForward>();
        playerDetected = GetComponent<PlayerDetected>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        enemyDeath = GetComponent<EnemyDeath>();

        //if alive
        if (!enemyDeath.IsDead) 
        {
            //check player
            if (playerDetected != null && playerDetected.isPlayerInRange)
            {
                //attack anim enable
                if (playerDetected.isAttack)
                {
                    animator.SetTrigger("RangedAttack");
                }
                //walk disable
                moveForward.enabled = false;
                animator.ResetTrigger("Walk");

            }
            //attack anim disable
            if (playerDetected != null && !playerDetected.isPlayerInRange)
            {
                animator.ResetTrigger("RangedAttack");
                moveForward.enabled = true;
            }
            // walk anim
            if (moveForward.enabled)
            {
                animator.SetTrigger("Walk");
            }
        }
        //if dead
        else
        {
            animator.SetBool("IsDead", true);
        }
    }

    private void ChangetAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}
