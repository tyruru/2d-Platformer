using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBar : MonoBehaviour
{
    public Image[] images;
    public FireProjectile fireProjectile;

    private void Awake()
    {
        fireProjectile.ShootCountChanged += OnShootCountChanged;
    }

    private void OnShootCountChanged(int countShoot)
    {
        ChangedWeaponbar(countShoot);
    }

    private void ChangedWeaponbar(int shootCount)
    {
        for (int i = shootCount; i < 3; i++)
        {
            Color color = images[i].color;
            color.a = 0.5f;
            images[i].color = color;
        }

        for (int i = 0; i < shootCount; i++)
        {
            Color color = images[i].color;
            color.a = 1f;
            images[i].color = color;
        }
    }

    private void OnDestroy()
    {
        fireProjectile.ShootCountChanged -= OnShootCountChanged;
    }
}
