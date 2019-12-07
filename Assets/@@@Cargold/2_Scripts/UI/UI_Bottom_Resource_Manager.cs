using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bottom_Resource_Manager : MonoBehaviour
{
    public static UI_Bottom_Resource_Manager Instance;

    public TextMeshProUGUI haveGoldTMP;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;
        }
        else if(_layer == 1)
        {
            UserSystem_Manager.Instance.Subscribe_Func(CallDel_HaveGoldChanged_Func);
        }

        yield break;
    }

    public void SetGold_Func(int _value)
    {
        haveGoldTMP.text = _value.ToString();
    }

    private void CallDel_HaveGoldChanged_Func(int _value)
    {
        this.SetGold_Func(_value);
    }
}
