using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Time_Manager : MonoBehaviour
{
    public static UI_Time_Manager Instance;

    public TextMeshProUGUI dayTMP;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;
        }
        else if(_layer == 1)
        {
            TimeSystem_Manager.Instance.Subscribe_DayPass_Func(CallDel_DayPass_Func);
        }

        yield break;
    }

    private void CallDel_DayPass_Func(int _day)
    {
        dayTMP.text = StringBuilder_C.Append_Func(_day.ToString(), "일차");
    }
}
