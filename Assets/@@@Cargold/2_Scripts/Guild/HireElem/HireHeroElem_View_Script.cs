using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HireHeroElem_View_Script : MonoBehaviour
{
    public Image portraitImg;
    public TextMeshProUGUI titleTxt;
    public TextMeshProUGUI hireCostTxt;

    public GameObject selectedObj;

    public GameObject soldOutObj;

    public void Init_Func()
    {
        selectedObj.SetActive(false);
        soldOutObj.SetActive(false);
    }

    public void Activate_Func(Sprite _portraitSprite, string _title, string _hireCost)
    {
        portraitImg.sprite = _portraitSprite;
        this.titleTxt.text = _title;
        this.hireCostTxt.text = _hireCost;
    }

    public void Selected_Func()
    {
        selectedObj.SetActive(true);
    }
    public void Deselected_Func()
    {
        selectedObj.SetActive(false);
    }

    public void SoldOut_Func()
    {
        this.soldOutObj.SetActive(true);
    }

    public void Deactivate_Func()
    {

    }
}
