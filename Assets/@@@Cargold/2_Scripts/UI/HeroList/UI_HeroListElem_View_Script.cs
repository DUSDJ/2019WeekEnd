using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HeroListElem_View_Script : MonoBehaviour
{
    public Image portraitImg;
    public TextMeshProUGUI titleTxt;
    public Image stressImg;
    public GameObject selectedObj;

    private const float reviseFill = 0.13f;

    public void Init_Func()
    {
        this.Deactivate_Func();
    }

    public void Activate_Func(Sprite _portraitSprite, string _title)
    {
        this.gameObject.SetActive(true);

        this.portraitImg.sprite = _portraitSprite;

        this.SetTitle_Func(_title);

        selectedObj.SetActive(false);
    }

    public void SetTitle_Func(string _title)
    {
        this.titleTxt.text = _title;
    }
    public void SetStress_Func(float _fillAmount)
    {
        _fillAmount = (_fillAmount * (1f - reviseFill)) + reviseFill;

        this.stressImg.fillAmount = _fillAmount;
    }

    public void Selected_Func(bool _isOn)
    {
        selectedObj.SetActive(_isOn);
    }

    public void Deactivate_Func()
    {
        this.gameObject.SetActive(false);
    }
}
