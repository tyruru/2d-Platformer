using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = .6f;
    public bool canWalk;

    private Rigidbody2D body2d;

    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        canWalk = true;
        body2d.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

}
