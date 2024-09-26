using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    public string targetTag = "Player";

    private void OnTriggerStay2D(Collider2D target)
    {
        if(target.gameObject.tag == targetTag)
        {
            OnCollect(target.gameObject);
            OnDestroy();
        }
    }

    protected virtual void OnCollect(GameObject target)
    {

    }

    protected virtual void OnDestroy()
    {
        Destroy(gameObject);
    }
}
