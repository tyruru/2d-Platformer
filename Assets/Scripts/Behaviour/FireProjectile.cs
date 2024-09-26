using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehaviour
{
    public float shootDelay = .5f;
    public int shootCount = 0;
    public GameObject projectilePrefab;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.yellow;
    public float debugRadius = 1f;

    public event Action<int> ShootCountChanged;
    public static event Action OnFire;

    private float timeElapsed = 0f;

    void Update()
    {
        ShootCountChanged?.Invoke(shootCount);

        if (projectilePrefab != null)
        {
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if(canFire && timeElapsed > shootDelay && shootCount > 0)
            {
                CreateProjectile(CalculateFirePosition());
                timeElapsed = 0;
                shootCount--;

                OnFire?.Invoke();
            }
            timeElapsed += Time.deltaTime;
        }
    }

    Vector2 CalculateFirePosition()
    {
        var pos = firePosition;
        pos.x *= (float)inputState.directions;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    public void CreateProjectile(Vector2 pos)
    {
        var clone = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
        clone.transform.localScale = transform.localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;

        var pos = firePosition;
        if (inputState != null)
            pos.x *= (float)inputState.directions;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
