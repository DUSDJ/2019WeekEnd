using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldDungeon_View_Script : MonoBehaviour
{
    public Image timerImg;

    public void Init_Func()
    {

    }

    public void Activate_Func()
    {

    }

    public void SetTimer_Func(float _fillAmount)
    {
        timerImg.fillAmount = _fillAmount;
    }
}
