using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip deathSound;
    public AudioClip fireballSound;

    private void OnEnable()
    {
        Jump.OnJumped += JumpSound;
        Death.OnHeroDead += DeathSound;
        FireProjectile.OnFire += FireballSound;
    }

    private void OnDisable()
    {
        Jump.OnJumped -= JumpSound;
        Death.OnHeroDead -= DeathSound;
        FireProjectile.OnFire -= FireballSound;
    }

    void JumpSound()
    {
        if (jump) AudioSource.PlayClipAtPoint(jump, transform.position);
    }

    void DeathSound()
    {
        if (deathSound) AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void FireballSound()
    {
        if (fireballSound) AudioSource.PlayClipAtPoint(fireballSound, transform.position);
    }
}
