using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject house;
    public GameObject houseInfoPanel;
    public GameObject houseHirePanel;
    public GameObject houseRecreationPanel;
    public GameObject houseReinforcePanel;

    public void Show()
    {
        house.SetActive(true);
        InfoShow();
    }

    public void Hide()
    {
        house.SetActive(false);
    }

    public void InfoShow()
    {
        houseInfoPanel.SetActive(true);
    }
    public void InfoHide()
    {
        houseInfoPanel.SetActive(false);
    }

    public void HireMenu(bool show)
    {
        if (show)
        {
            InfoHide();
            houseHirePanel.SetActive(true);
        }
        else
        {
            houseHirePanel.SetActive(false);
            Hide();
            return;
        }

        
    }

}
