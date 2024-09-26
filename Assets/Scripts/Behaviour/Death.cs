using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Death : MonoBehaviour
{
    public DeathMenu deathMenu;
    public bool IsDead { get; private set; }

    public static Action OnHeroDead;

    private void Start()
    {
        IsDead = false;
    }

    private void Update()
    {
        if (transform.position.y < -8)
        {
            OnDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            OnDeath(); 
        }
    }

    public void OnDeath()
    {
        if (IsDead == false) OnHeroDead?.Invoke();

        IsDead = true;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<FaceDirection>().enabled = false;

       
    }


    public void DeathMenu()
    {
        deathMenu.LoseGame();
    }

}
