using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Script : MonoBehaviour
{
    [SerializeField] private Resume_View_Script viewClass;
    private HeroType heroType;
    private string job;
    private string heroName;
    private string heroDesc;
    private int hireCost;
    private int heroLevel;

    public void Init_Func()
    {
        viewClass.Init_Func();
    }

    public void Activate_Func(HeroData _heroData)
    {
        this.heroType = _heroData.heroType;
        this.job = _heroData.job;
        this.heroName = _heroData.heroName;
        this.heroDesc = _heroData.heroDesc;
        this.hireCost = _heroData.hireCost;
        this.heroLevel = _heroData.herolevel;

        Sprite _torsoSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroData.heroType).torsoSprite;
        viewClass.Activate_Func(_torsoSprite, _heroData.job, _heroData.heroDesc, _heroData.hireCost.ToString(), _heroData.isHirable);
    }

    public void CallBtn_Hired_Func()
    {
        if(UserSystem_Manager.Instance.TryControlResource_Func(UserSystem_Manager.ResourceControlType.Cost, this.hireCost) == true)
        {
            UserSystem_Manager.HireHeroData _hireHeroData;
            _hireHeroData.heroType = this.heroType;
            _hireHeroData.heroName = this.heroName;
            _hireHeroData.heroLevel = this.heroLevel;
            UserSystem_Manager.Instance.HireHero_Func(_hireHeroData);

            GuildSystem_Manager.Instance.HiredselectedHero_Func();

            viewClass.Hired_Func();
        }
    }

    public struct HeroData
    {
        public HeroType heroType;
        public string job;
        public string heroName;
        public string heroDesc;
        public int hireCost;
        public int herolevel;
        public bool isHirable;
    }
}
