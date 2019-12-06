using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject houseInfoPanel;

    public void Show()
    {
        houseInfoPanel.SetActive(true);
    }

    public void Hide()
    {
        houseInfoPanel.SetActive(false);
    }
}
