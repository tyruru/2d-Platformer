using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundEffects : MonoBehaviour
{
    public AudioClip deathEffect;
    public AudioClip enemyFireEffect;

    private void OnEnable()
    {
        EnemyDeath.OnEnemyDead += DeathSound;
        EnemieFireProjectile.OnEnemyFire += FireEnemySound;
    }

    private void OnDisable()
    {
        EnemyDeath.OnEnemyDead -= DeathSound;
        EnemieFireProjectile.OnEnemyFire -= FireEnemySound;
    }

    public void DeathSound()
    {
        AudioSource.PlayClipAtPoint(deathEffect, transform.position);
    }

    public void FireEnemySound()
    {
        AudioSource.PlayClipAtPoint(enemyFireEffect, transform.position);
    }
}
