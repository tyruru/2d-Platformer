using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(100, -100);

    private Rigidbody2D body2d;

    void Start()
    {
        var startVelX = initialVelocity.x * transform.localScale.x;

        body2d.velocity = new Vector2(startVelX, initialVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Enemy")
        {
            target.gameObject.GetComponent<EnemyDeath>().FireballDamage();
        }
        Destroy(gameObject);
    }

    private void EnemyDamage()
    {

    }

    private void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }
}
