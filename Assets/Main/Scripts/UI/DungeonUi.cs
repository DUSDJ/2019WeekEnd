using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUi : MonoBehaviour
{
    public GameObject dungeonInfoPanel;

    [Header("Infomation UI")]
    public Text dungeonName;

    public void Show(int index)
    {
        dungeonInfoPanel.SetActive(true);
        dungeonName.text = index.ToString();
    }

    public void Hide()
    {
        dungeonInfoPanel.SetActive(false);

    }
}
