using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    public void Show()
    {
        anim.SetTrigger("IsShow");
    }
}
