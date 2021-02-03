using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetHoverAnimation()
    {
        anim.SetBool("hovered", true);
    }
    public void UndoHoverAnimation()
    {
        anim.SetBool("hovered", false);
    }

}
