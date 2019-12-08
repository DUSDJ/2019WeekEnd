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
    private int str;
    private int agi;
    private int intel;

    private const string desc = "제국의 용병 길드가 보증하는 위 이력서는, 다음과 같이 용병을 소개하겠다. " +
        "{0}은(는) {1}레벨의 {2}이며 용병 길드에 적법한 과정을 통해 공식적으로 등록되었다.\n\n " +
        "{0}은(는) 힘 {3}, 민첩 {4}, 지능 {5}을 지녔음을 보증한다.\n\n " +
        "만약 위 이력서를 발견하였다면 즉시 가까운 용병 길드에 반납해야 한다.";

    public void Init_Func()
    {
        viewClass.Init_Func();
    }

    public void Activate_Func(HeroData _heroData)
    {
        this.heroType = _heroData.heroType;
        this.job = _heroData.job;
        this.heroName = _heroData.heroName;
        this.heroDesc = string.Format(desc, _heroData.heroName, _heroData.heroLevel, _heroData.job, _heroData.str, _heroData.agi, _heroData.intel);
        this.hireCost = _heroData.hireCost;
        this.heroLevel = _heroData.heroLevel;

        

        Sprite _torsoSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroData.heroType).torsoSprite;
        viewClass.Activate_Func(_torsoSprite, _heroData.job, this.heroDesc, _heroData.hireCost.ToString(), _heroData.isHirable);
    }

    public void Hired_Func()
    {
        viewClass.Hired_Func();
    }

    public void CallBtn_Hired_Func()
    {
        GuildSystem_Manager.Instance.HiredselectedHero_Func();
    }

    public struct HeroData
    {
        public HeroType heroType;
        public string job;
        public string heroName;
        public string heroDesc;
        public int hireCost;
        public int heroLevel;
        public bool isHirable;
        public int str;
        public int agi;
        public int intel;
    }
}
