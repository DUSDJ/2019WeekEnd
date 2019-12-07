using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;

public class UI_HeroListElem_Script : MonoBehaviour, IGeneratedByPoolingSystem, IWhichOne
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
    }

    void IWhichOne.SelectCancel_Func()
    {
        viewClass.Selected_Func(false);
    }
}
