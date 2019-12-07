using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlSystem_Manager : MonoBehaviour
{
    public static UserControlSystem_Manager Instance;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        yield break;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {

        }
    }
}
