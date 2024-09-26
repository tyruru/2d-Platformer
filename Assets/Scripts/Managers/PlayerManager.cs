using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputState inputState;
    private Walk walk;
    private Animator animator;
    private CollisionState collisionState;
    private Death death;
    private bool isDead;


    void Start()
    {
        inputState = GetComponent<InputState>();
        walk = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        death = GetComponent<Death>();
    }

    private void Update()
    {
        isDead = death.IsDead;

        if (isDead == false)
        {
            //standing
            if (collisionState.standing)
                ChangedAnimationState(0);
            //walk
            if (inputState.absVelX > 0 && !walk.running)
                ChangedAnimationState(1);
            //running
            if (inputState.absVelX > 0 && walk.running)
                ChangedAnimationState(2);
            //jump
            if (!collisionState.standing)
                ChangedAnimationState(3);
        }
        //dead
        else
        {
            animator.SetInteger("AnimState", -1);
        }

    }

    void ChangedAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}
