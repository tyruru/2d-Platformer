using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 initialVelocity = new(100, -100);

    private Rigidbody2D body2d;

    void Start()
    {
        var startVelocityX = initialVelocity.x * transform.localScale.x;
        body2d.velocity = new Vector2(startVelocityX, initialVelocity.y);
    }

    private void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        Destroy(gameObject);

        if(target.gameObject.tag == "Player")
        {
            var dead = target.gameObject.GetComponent<Death>();
            dead.OnDeath();
        }
    }
}
