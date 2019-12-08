using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.Observer;
using System;

public class DataBase_Manager : MonoBehaviour
{
    public static DataBase_Manager Instance;

    public Hero hero;
    public Test test;
    public Dungeon dungeon;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        hero.Init_Func();

        yield break;
    }

    [System.Serializable]
    public class Hero
    {
        public Dictionary<HeroType, Hero.HeroData> heroDataDic;

        public Hero.HeroData[] heroDataArr;

        public void Init_Func()
        {
            this.heroDataDic = new Dictionary<HeroType, HeroData>();

            foreach (HeroData _heroData in heroDataArr)
                this.heroDataDic.Add_Func(_heroData.heroType, _heroData);
        }

        public String GetHeroName_Func(HeroType _heroType)
        {
            return this.heroDataDic.GetValue_Func(_heroType).nameArr.GetRandItem_Func();
        }
        
        [System.Serializable]
        public struct HeroData
        {
            public HeroType heroType;
            public Sprite portraitSprite;
            public Sprite torsoSprite;
            public string job;
            public string[] nameArr;
        }
    }

    [System.Serializable]
    public class Dungeon
    {
        public LevelData[] levelDataArr;

        public int rewardDefault;
        public float rewardMulti;
        public float rewardReviseMin;
        public float rewardReviseMax;

        public float dungeonLastTimeMin;
        public float dungeonLastTimeMax;

        public float[] levelRewardBonusArr;

        [System.Serializable]
        public struct LevelData
        {
            public int needDay;
            public int[] levelGeneratePerArr;
        }
    }

    [System.Serializable]
    public class Test
    {
        public int startGold;
        public float dayPassTime;
        public int heroLvMax;
    }
}