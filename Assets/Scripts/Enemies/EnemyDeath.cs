using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDeath : MonoBehaviour
{
    public bool IsDead { get; private set; }

    public static Action OnEnemyDead;

    public void FireballDamage()
    {
        OnEnemyDeath();
    }

    private void OnEnemyDeath()
    {
        IsDead = true;
        gameObject.tag = "Untagged";
        GetComponent<MoveForward>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        OnEnemyDead?.Invoke();

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
