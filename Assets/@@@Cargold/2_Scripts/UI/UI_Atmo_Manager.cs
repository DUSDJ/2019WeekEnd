using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Atmo_Manager : MonoBehaviour
{
    public static UI_Atmo_Manager Instance;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        yield break;
    }
}
