using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{

    public AudioClip clickSound;
    public AudioClip hoverSound;


    public void ClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
    }

    public void HoverSound()
    {
        AudioSource.PlayClipAtPoint(hoverSound, transform.position);
    }
}
