using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDetected : MonoBehaviour
{
    public CircleCollider2D boxCollider;
    public LayerMask playerLayer;
    public float attackCooldown;
    public float range;
    public float colliderDistance;
    public bool isPlayerInRange = false;
    public bool isAttack = false;

    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;



    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            isPlayerInRange = true;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                isAttack = true;
            }
        }
        else
        {          
            isAttack = false;
            isPlayerInRange = false;
        }
    }
     
    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);


        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)); 
    }
}
