using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldDungeon_View_Script : MonoBehaviour
{
    public Image timerImg;

    public void Init_Func()
    {
        Deactivate_Func();
    }

    public void Activate_Func()
    {
        this.gameObject.SetActive(true);
    }

    public void SetTimer_Func(float _fillAmount)
    {
        timerImg.fillAmount = _fillAmount;
    }

    public void SetExpeditionState_Func()
    {

    }

    public void Deactivate_Func()
    {
        this.gameObject.SetActive(false);
    }
}
