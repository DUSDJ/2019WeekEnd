using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;

public class UI_HeroListElem_Script : MonoBehaviour, IGeneratedByPoolingSystem, IWhichOne, ICharacter
{
    public UI_HeroListElem_View_Script viewClass;

    private UserHeroData userHeroData;
    private ElemExpeditionState elemExpeditionState;

    public UserHeroData UserHeroData { get => userHeroData; }
    public ElemExpeditionState CurrentExpeditionState { get => elemExpeditionState; }

    public void Init_Func()
    {
        viewClass.Init_Func();

        elemExpeditionState = ElemExpeditionState.None;
    }

    public void Activate_Func(UserHeroData _userHeroData)
    {
        this.userHeroData = _userHeroData;

        var _heroType = _userHeroData.heroType;
        Sprite _portraitSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).portraitSprite;
        string _title = StringBuilder_C.Append_Func("Lv. ", _userHeroData.heroLevel.ToString(), " ", _userHeroData.heroName);

        viewClass.Activate_Func(_portraitSprite, _title);
    }
    public void SetState_Expedition_Func(ElemExpeditionState _elemExpeditionState)
    {
        switch (_elemExpeditionState)
        {
            case ElemExpeditionState.WaitOrder:
                this.elemExpeditionState = ElemExpeditionState.WaitOrder;
                break;

            case ElemExpeditionState.Arrangement:
                this.elemExpeditionState = ElemExpeditionState.Arrangement;
                break;

            case ElemExpeditionState.Expediting:
                this.elemExpeditionState = ElemExpeditionState.Expediting;
                break;

            default:
                break;
        }

        viewClass.SetState_Func(_elemExpeditionState);
    }
    public void Deactivate_Func()
    {
        viewClass.Deactivate_Func();
    }

    public void CallBtn_Selected_Func()
    {
        UserControlSystem_Manager.ControlState _currentControlState = UserControlSystem_Manager.Instance.CurrentControlState;

        switch (_currentControlState)
        {
            case UserControlSystem_Manager.ControlState.Dungeon_Activate:
            case UserControlSystem_Manager.ControlState.Dungeon_SlotSelected:
                if(this.elemExpeditionState == ElemExpeditionState.WaitOrder)
                {
                    UI_HeroList_Manager.Instance.SelectedElem_Func(this);
                }
                break;

            default:
                UI_HeroList_Manager.Instance.SelectedElem_Func(this);
                break;
        }
    }

    void IGeneratedByPoolingSystem.CallI_GenerateByPoolingSystem_Func()
    {
        this.Init_Func();
    }

    void IWhichOne.Selected_Func(bool _repeat)
    {
        viewClass.Selected_Func(true);

        //HeroInfoManager _heroInfoManager = null;
        //_heroInfoManager.Show(this);
    }

    void IWhichOne.SelectCancel_Func()
    {
        viewClass.Selected_Func(false);

        this.SetState_Expedition_Func(ElemExpeditionState.WaitOrder);
    }

    public string GetName() => userHeroData.heroName;
    public int GetLevel() => userHeroData.heroLevel;
    public int GetStrength() => this.userHeroData.strength;
    public int GetAgility() => this.userHeroData.agility;
    public int GetIntelligence() => this.userHeroData.intelligence;
    public bool GetNeedCounsel() => this.userHeroData.isNeedCounsel;
    public int GetStress() => this.userHeroData.stressPoint;
    public void AddStress(int _stress) => this.userHeroData.stressPoint += _stress;

    public Sprite GetIcon()
    {
        Sprite _iconSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(this.userHeroData.heroType).portraitSprite;
        return _iconSprite;
    }

    public HeroType GetHeroType()
    {
        return this.userHeroData.heroType;
    }

    public enum ElemExpeditionState
    {
        None = 0,

        WaitOrder,
        Arrangement,
        Expediting,
    }
}
