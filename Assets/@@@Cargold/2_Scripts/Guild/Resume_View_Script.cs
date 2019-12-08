using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resume_View_Script : MonoBehaviour
{
    public Image torsoImg;
  public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI jobTMP;
    public TextMeshProUGUI descTMP;
    public TextMeshProUGUI costTMP;

    public GameObject hireBtnObj;
    public GameObject hiredBtnObj;

    public void Init_Func()
    {

    }

    public void Activate_Func(Sprite _torsoSprite, string _job, string _desc, string _cost, bool _isHirable, string _name)
    {
        this.torsoImg.sprite = _torsoSprite;
        this.jobTMP.text = _job;
        this.descTMP.text = _desc;
        this.costTMP.text = _cost;
    this.nameTMP.text = _name;

        if(_isHirable == true)
        {
            hireBtnObj.SetActive(true);
            hiredBtnObj.SetActive(false);
        }
        else
        {
            hireBtnObj.SetActive(false);
            hiredBtnObj.SetActive(true);
        }
    }

    public void Hired_Func()
    {
        hireBtnObj.SetActive(false);
        hiredBtnObj.SetActive(true);
    }
}
