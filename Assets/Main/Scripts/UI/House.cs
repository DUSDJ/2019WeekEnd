using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public GameObject house;
    public GameObject houseInfoPanel;
    public GameObject houseHirePanel;
    public GameObject houseRecreationPanel;
    public GameObject houseReinforcePanel;

    public GameObject HireSlotPrefab;
    public RectTransform HireLayout;
    public List<GameObject> HireSlotList = new List<GameObject>();
    
    [System.Serializable]
    public struct DetailStruct
    {
        public GameObject go;
        public Image HireTorso;
        public Text HireJob;
        public Text HireDetail;
        public Text AdditionalText;
        public Text AdditionalText2;
        public Text Cost;

    }
    public DetailStruct detailStruct;

    public void Show()
    {
        house.SetActive(true);
        InfoShow();
    }

    /* Delegate... */
    public void Hide()
    {
        InfoHide();
        HireMenu(false);

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


    public void InitHireResume()
    {
        detailStruct.go.SetActive(false);
    }
    public void UpdateHireResume(Character chara)
    {
        detailStruct.go.SetActive(true);
        detailStruct.HireTorso.sprite = chara.Torso;
        detailStruct.HireJob.text = chara.CharacterJobToString();
        detailStruct.HireDetail.text = "미정";
        detailStruct.AdditionalText.text = "추가 정보 확인 불가";
        detailStruct.AdditionalText.text = "추가 정보 확인 불가";
        detailStruct.Cost.text = "고용 : " + chara.Cost.ToString() + "G";
    }
    public void UpdateHireMenu()
    {
        List<Character> wh = GameManager.Instance.HireManager.WaitingCharacters;

        if (HireSlotList.Count == 0)
        {
            for (int i = 0; i < wh.Count; i++)
            {
                GameObject go = Instantiate(HireSlotPrefab, HireLayout);
                go.GetComponent<HireSlot>().chara = wh[i];
                go.GetComponent<HireSlot>().Init();

                HireSlotList.Add(go);
            }
        }
        else
        {
            if(HireSlotList.Count > wh.Count)
            {
                for (int i = 0; i < HireSlotList.Count; i++)
                {
                    if (i > wh.Count - 1)
                    {
                        HireSlotList[i].GetComponent<HireSlot>().chara = null;
                        HireSlotList[i].GetComponent<HireSlot>().Init();
                        HireSlotList[i].SetActive(false);
                        continue;
                    }

                    HireSlotList[i].GetComponent<HireSlot>().chara = wh[i];
                    HireSlotList[i].GetComponent<HireSlot>().Init();

                }
            }
            else
            {
                for (int i = 0; i < wh.Count; i++)
                {
                    if (i > HireSlotList.Count - 1)
                    {
                        GameObject go = Instantiate(HireSlotPrefab, HireLayout);
                        go.GetComponent<HireSlot>().chara = wh[i];
                        go.GetComponent<HireSlot>().Init();
                        HireSlotList.Add(go);
                        continue;
                    }
                    HireSlotList[i].SetActive(true);
                    HireSlotList[i].GetComponent<HireSlot>().chara = wh[i];
                    HireSlotList[i].GetComponent<HireSlot>().Init();

                }
            }

           
        }
    }


    public void HireMenu(bool show)
    {
        if (show)
        {
            InfoHide();
            houseHirePanel.SetActive(true);

            UpdateHireMenu();


        }
        else
        {
            houseHirePanel.SetActive(false);

            return;
        }

    }

}
