using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class DungeonResultView : MonoBehaviour
{
    public static DungeonResultView Instance;

    public TextMeshProUGUI dungeonLevelText;
    public TextMeshProUGUI stressText;
    public TextMeshProUGUI passDayText;
    public TextMeshProUGUI rewardText;

    public string[] dungeonLevels = new string[5]{"매우 쉬움", "쉬움", "보통", "어려움", "매우 어려움" };

    public ICharacter[] heroDatas;
    public DungeonResultHeroSlot[] dungeonResultHeroSlots;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        this.Deactivate_Func(true);

        yield break;
    }

    public void UpdateView(FieldDungeon_Script resultDataBus)
    {
        this.gameObject.SetActive(true);

        FieldDungeon_Script.DungeonResultData _resultData = resultDataBus.GetDungeonResultData_Func();
        dungeonLevelText.text = dungeonLevels[(int)_resultData.dungeonLevel];
        stressText.text = string.Format(_resultData.stress.ToString());
        passDayText.text = string.Format(_resultData.passDay.ToString());
        rewardText.text = string.Format(_resultData.reward.ToString());

        UI_HeroListElem_Script[] _elemClassArr = resultDataBus.HeroListElemArr;

        for (int i = 0; i < dungeonResultHeroSlots.Length; i++)
        {
            if(i < _elemClassArr.Length)
            {
                UserHeroData _userHeroData = _elemClassArr[i].UserHeroData;
                HeroType _heroType = _userHeroData.heroType;
                int _originLv = _userHeroData.heroLevel;
                int _gainLv = (int)_resultData.dungeonLevel;
                int _originStress = _userHeroData.stressPoint;
                int _gainStress = _resultData.stress;
                
                Sprite _iconSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).portraitSprite;
                string _heroName = _userHeroData.heroName;
                dungeonResultHeroSlots[i].SetHeroData(_iconSprite, _heroName, _originLv, _gainLv, _originStress, _gainStress);

                _userHeroData.AddLevel_Func(_gainLv);
                _userHeroData.AddStress_Func(_gainStress);
            }
            else
            {
                dungeonResultHeroSlots[i].Clear_Func();
            }
        }

        UserSystem_Manager.Instance.TryControlResource_Func(UserSystem_Manager.ResourceControlType.Earn, _resultData.reward);

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.Dungeon_Result);
    }

    public void CallBtn_Close_Func()
    {
        this.Deactivate_Func();
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if(_isInit == false)
            UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.MainField);

        this.gameObject.SetActive(false);
    }
}
