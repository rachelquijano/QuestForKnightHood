using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{

    public void SetHoverAnimation()
    {
        transform.DOScale(1.3f, 0.5f);
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void UndoHoverAnimation()
    {
        transform.DOScale(1f, 0.5f);
    }

}
