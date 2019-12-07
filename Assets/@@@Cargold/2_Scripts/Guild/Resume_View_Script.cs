using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resume_View_Script : MonoBehaviour
{
    public Image torsoImg;
    public TextMeshProUGUI jobTMP;
    public TextMeshProUGUI descTMP;
    public TextMeshProUGUI costTMP;

    public void Init_Func()
    {

    }

    public void Activate_Func(Sprite _torsoSprite, string _job, string _desc, string _cost)
    {
        this.torsoImg.sprite = _torsoSprite;
        this.jobTMP.text = _job;
        this.descTMP.text = _desc;
        this.costTMP.text = _cost;
    }
}
