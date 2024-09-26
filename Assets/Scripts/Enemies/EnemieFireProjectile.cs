using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemieFireProjectile : MonoBehaviour
{
    public GameObject bullet;
    public Vector2 firePosition = Vector2.zero;
    public float debugRadius;

    public static event Action OnEnemyFire;

    public void CreateBullet()
    {
        OnEnemyFire?.Invoke();
        var pos = CalculateFirePosition();
        var clone = Instantiate(bullet, pos, Quaternion.identity) as GameObject;
        clone.transform.localScale = transform.localScale;
    }


    private Vector2  CalculateFirePosition()
    {
        var pos = firePosition;
        pos.x *= transform.localScale.x == 1 ? 1 : -1;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        var pos = firePosition;
        pos.x *= transform.localScale.x == 1 ? 1 : -1;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
