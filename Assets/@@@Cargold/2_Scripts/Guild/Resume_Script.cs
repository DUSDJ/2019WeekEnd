using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Script : MonoBehaviour
{
    [SerializeField] private Resume_View_Script viewClass;

    public void Init_Func()
    {
        viewClass.Init_Func();
    }

    public void Activate_Func(HeroData _heroData)
    {
        Sprite _torsoSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroData.heroType).torsoSprite;
        viewClass.Activate_Func(_torsoSprite, _heroData.job, _heroData.heroDesc, _heroData.hireCost.ToString());
    }

    public struct HeroData
    {
        public HeroType heroType;
        public string job;
        public string heroDesc;
        public int hireCost;
    }
}
