using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;

public class HireHeroElem_Script : MonoBehaviour, IGeneratedByPoolingSystem, IWhichOne
{
    public HireHeroElem_View_Script viewClass;

    public HeroType heroType;
    public string heroName;
    public int heroLevel;
    public int hireCost;
    public bool isHirable;

    public void Init_Func()
    {
        viewClass.Init_Func();
    }

    public void Activate_Func(HeroData _heroData)
    {
        HeroType _heroType = _heroData.heroType;
        this.heroType = _heroType;
        this.heroName = _heroData.heroName;
        this.heroLevel = _heroData.heroLevel;
        this.hireCost = _heroData.hireCost;
        this.isHirable = true;

        Sprite _portraitSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).portraitSprite;
        string _title = StringBuilder_C.Append_Func("Lv. ", this.heroLevel.ToString(), " ", heroName);
        viewClass.Activate_Func(_portraitSprite, _title, this.hireCost.ToString());
    }
    public void SetSoldOut_Func()
    {
        if(isHirable == true)
        {
            this.isHirable = false;

            viewClass.SoldOut_Func();
        }
        else
        {
            Debug_C.Error_Func("?");
        }
    }

    public void Deactivate_Func()
    {
        viewClass.Deactivate_Func();

        this.gameObject.SetActive(false);

        GuildSystem_Manager.Instance.DeactivateElem_Func(this);
    }

    public void CallBtn_Selected_Func()
    {
        GuildSystem_Manager.Instance.SelectedElem_Func(this);
    }

    void IGeneratedByPoolingSystem.CallI_GenerateByPoolingSystem_Func()
    {
        this.Init_Func();
    }

    void IWhichOne.Selected_Func(bool _repeat)
    {
        viewClass.Selected_Func();
    }
    void IWhichOne.SelectCancel_Func()
    {
        viewClass.Deselected_Func();
    }

    public struct HeroData
    {
        public HeroType heroType;
        public string heroName;
        public int heroLevel;
        public int hireCost;
    }
}

public enum HeroType
{
    Nun,
    Barbarian,
    Pirate,
    PirateW,
    Priest,
    Drawf,
    Knight,
    BarbarianW,
}