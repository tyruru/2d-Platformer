using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : Collactable
{
    public int itemID = 1;
    public GameObject projectilePrefab;
    public AudioClip takeRune;
    

    protected override void OnCollect(GameObject target)
    {
        var equipBehavior = target.GetComponent<Equip>();
        if(equipBehavior != null)
        {
            equipBehavior.CurrentItem = itemID;
        }

        var shootBehavior = target.GetComponent<FireProjectile>();

        if(shootBehavior != null)
        {
            shootBehavior.projectilePrefab = projectilePrefab;
            shootBehavior.shootCount = 3;

            AudioSource.PlayClipAtPoint(takeRune, transform.position, 0.5f);
        }

        
    }
}
