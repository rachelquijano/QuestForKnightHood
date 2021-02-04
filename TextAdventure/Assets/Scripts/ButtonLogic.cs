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
    }
    public void UndoHoverAnimation()
    {
        transform.DOScale(1f, 0.5f);
    }

}
