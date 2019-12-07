using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;

public class UI_HeroListElem_Script : MonoBehaviour, IGeneratedByPoolingSystem, IWhichOne, ICharacter
{
    public UI_HeroListElem_View_Script viewClass;

    private UserHeroData userHeroData;

    public void Init_Func()
    {
        viewClass.Init_Func();
    }

    public void Activate_Func(UserHeroData _userHeroData)
    {
        this.userHeroData = _userHeroData;

        var _heroType = _userHeroData.heroType;
        Sprite _portraitSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).portraitSprite;
        string _title = StringBuilder_C.Append_Func("Lv. ", _userHeroData.heroLevel.ToString(), " ", _userHeroData.heroName);

        viewClass.Activate_Func(_portraitSprite, _title);
    }

    public void Deactivate_Func()
    {
        viewClass.Deactivate_Func();
    }

    public void CallBtn_Selected_Func()
    {
        UI_HeroList_Manager.Instance.SelectedElem_Func(this);
    }

    void IGeneratedByPoolingSystem.CallI_GenerateByPoolingSystem_Func()
    {
        this.Init_Func();
    }

    void IWhichOne.Selected_Func(bool _repeat)
    {
        viewClass.Selected_Func(true);

        HeroInfoManager _heroInfoManager = null;
        _heroInfoManager.Show(this);
    }

    void IWhichOne.SelectCancel_Func()
    {
        viewClass.Selected_Func(false);
    }

    public string GetName() => userHeroData.heroName;
    public int GetLevel() => userHeroData.heroLevel;
    public int GetStrength() => this.userHeroData.strength;
    public int GetAgility() => this.userHeroData.agility;
    public int GetIntelligence() => this.userHeroData.intelligence;
    public bool GetNeedCounsel() => this.userHeroData.isNeedCounsel;
    public int GetStress() => this.userHeroData.stressPoint;
    public void AddStress(int _stress) => this.userHeroData.stressPoint += _stress;
    HeroType ICharacter.GetJob() => this.userHeroData.heroType;
}
