using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DungeonInfoView : MonoBehaviour
{
    public static DungeonInfoView Instance;

    public TextMeshProUGUI dungeonLevelText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI stressText;
    public TextMeshProUGUI passDayText;

    public TextMeshProUGUI averageStressText;

    public RectTransform averageStressIndicator;
    public Vector2 averageStressIndicatorMinPosition = new Vector2(0, 20),
        averageStressIndicatorMaxPosition = new Vector2(312, 20);

    public GameObject speechBubble;
    public TextMeshProUGUI speechBubbleText;

    public DungeonSlot[] dungeonSlots;

    // 1, 5, 10, 15, 20
    public string[] dungeonLevels = new string[5]{"매우 쉬움", "쉬움", "보통", "어려움", "매우 어려움" };
    public string[] speechs = new string[5]
    {
        "너무 과한 투자가 아닐까 싶습니다.",
        "단원들이 모두 걱정없이 돌아 오겠군요.",
        "이보다 좋은 팀은 없을겁니다.",
        "단원들에겐 큰 시련이 될 듯 합니다.",
        "단장님은 단원들을 사지로 몰 생각입니까?"
    };

    public IEnumerator Init_Cor()
    {
        Instance = this;

        this.Deactivate_Func(true);

        yield break;
    }

    public void UpdateView(FieldDungeon_Script.DungeonData dungeonData)
    {
        this.gameObject.SetActive(true);

        dungeonLevelText.text = dungeonLevels[(int)dungeonData.dungeonLevel];
        rewardText.text = string.Format(dungeonData.rewardMin + "\n-\n" + dungeonData.rewardMax);
        stressText.text = string.Format(dungeonData.stressMin + "\n-\n" + dungeonData.stressMax);
        passDayText.text = string.Format(dungeonData.passDayMin + "일\n-\n" + dungeonData.passDayMax + "일");

        averageStressText.text = string.Format("원정대 평균스트레스 0%");
        averageStressIndicator.anchoredPosition = averageStressIndicatorMinPosition;

        for (int ix = 0; ix < dungeonSlots.Length; ix++)
            dungeonSlots[ix].SetHeroData(null);

        speechBubble.SetActive(false);

        selectedSlot = null;

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.Dungeon_Activate);

        TimeSystem_Manager.Instance.Pause_Func();
    }

    public void UpdateAverageStress()
    {
        float totalStress = 0f;
        int heroCountOnSlot = 0;
        int totalLevel = 0;
        for (int ix = 0; ix < dungeonSlots.Length; ix++)
        {
            ICharacter temp = dungeonSlots[ix].GetHeroData();
            if (temp == null)
                continue;

            heroCountOnSlot++;
            totalStress += temp.GetStress();
            totalLevel += temp.GetLevel();
        }

        int averageStress = (int)(totalStress / heroCountOnSlot);
        averageStressText.text = string.Format("원정대 평균스트레스 {0}%", averageStress);
        averageStressIndicator.anchoredPosition =
            Vector2.Lerp(averageStressIndicatorMinPosition, averageStressIndicatorMaxPosition, averageStress / 100f);

        int averageLevel = (int)(totalLevel / heroCountOnSlot);
        int levelGrade = (int)(averageLevel / speechs.Length);

        speechBubble.SetActive(true);
        speechBubbleText.text = speechs[levelGrade];
    }

    public DungeonSlot selectedSlot;

    public void SetSelectedSlot(DungeonSlot slot)
    {
        selectedSlot = slot;

        for (int ix = 0; ix < dungeonSlots.Length; ix++)
        {
            if (dungeonSlots[ix] == slot)
            {
                dungeonSlots[ix].isSelected = true;

                UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.Dungeon_SlotSelected);
            }
            else
            {
                dungeonSlots[ix].isSelected = false;
            }
        }
    }

    public void SetHeroData(ICharacter hero)
    {
        if (selectedSlot != null)
            selectedSlot.SetHeroData(hero);
    }

    private void Expedition_Func()
    {
        List<UI_HeroListElem_Script> _HeroListElemClassList = new List<UI_HeroListElem_Script>();
        foreach (DungeonSlot _slotClass in this.dungeonSlots)
        {
            UI_HeroListElem_Script _elemClass = _slotClass.heroDataBus as UI_HeroListElem_Script;

            if(_elemClass != null)
                _HeroListElemClassList.AddNewItem_Func(_elemClass);
        }

        // 보유 영웅 엘렘 상태 변화 + 던전 아이콘 상태 변화
        FieldSystem_Manager.Instance.Expedition_Func(_HeroListElemClassList.ToArray());

        // UI 닫기
        this.Deactivate_Func();
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if(_isInit == false)
            UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.MainField);

        this.gameObject.SetActive(false);
    }

    public void CallBtn_Close_Func()
    {
        this.Deactivate_Func();
    }
    public void CallBtn_Expedition_Func()
    {
        this.Expedition_Func();
    }
}
