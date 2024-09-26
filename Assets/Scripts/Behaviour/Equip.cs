using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : AbstractBehaviour
{
    private int _currentItem = 0;
    private Animator animator;

    public int CurrentItem
    {
        get { return _currentItem; }
        set
        {
            _currentItem = value;
            animator.SetInteger("EquippedItem", _currentItem);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
    }
}
