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
    public Image bgImg;

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

    public void SetState_Func(UI_HeroListElem_Script.ElemExpeditionState expeditionState)
    {
        switch (expeditionState)
        {
            case UI_HeroListElem_Script.ElemExpeditionState.None:
                break;

            case UI_HeroListElem_Script.ElemExpeditionState.WaitOrder:
                bgImg.SetColorOnBaseAlpha_Func(Color.white);
                break;

            case UI_HeroListElem_Script.ElemExpeditionState.Arrangement:
                break;

            case UI_HeroListElem_Script.ElemExpeditionState.Expediting:
                bgImg.SetColorOnBaseAlpha_Func(new Color(0.5f, 0.5f, 0.5f, 1f));
                break;

            default:
                break;
        }
    }

    public void Deactivate_Func()
    {
        this.gameObject.SetActive(false);
    }
}
