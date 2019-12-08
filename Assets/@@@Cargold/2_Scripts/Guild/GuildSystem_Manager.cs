using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;
using Sirenix.OdinInspector;

public class GuildSystem_Manager : MonoBehaviour
{
    public static GuildSystem_Manager Instance;
    
    [SerializeField] private Transform elemGroupTrf;
    [SerializeField] private GameObject elemObj;
    [SerializeField] private Resume_Script resumeClass;
    [SerializeField] private GameObject guildObj;
    [SerializeField] private int guildElemResetDayCondition;
    [SerializeField] private List<HireHeroElem_Script> elemClassList;
    [SerializeField] private GenerateHero generateHeroClass;

    private PoolingSystem<HireHeroElem_Script> poolingSystem;
    private WhichOne<HireHeroElem_Script> whichOneClass;
    private GetHeroTypeRandom getHeroTypeRandomClass;
    private int guildElemResetDayCalc;
    private bool isReserveElemReset;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            // 자기 자신을 초기화

            Instance = this;

            poolingSystem = new PoolingSystem<HireHeroElem_Script>();
            poolingSystem.Init_Func(this.transform, elemObj, 3);
            
            for (int i = 0; i < elemClassList.Count; i++)
                GameObject.Destroy(elemClassList[i].gameObject);

            elemClassList.Clear();

            resumeClass.Init_Func();

            whichOneClass = new WhichOne<HireHeroElem_Script>();

            getHeroTypeRandomClass = new GetHeroTypeRandom();

            this.isReserveElemReset = true;
        }
        else if(_layer == 1)
        {
            // 타 클래스 접근하여 초기화

            TimeSystem_Manager.Instance.Subscribe_DayPass_Func(this.CallDel_DayPass_Func);
        }
        else if(_layer == 2)
        {
            // 세이브 데이터를 불러와서 초기화
        }

        yield break;
    }
    
    [Button]
    public void Activate_Func()
    {
        guildObj.SetActive(true);
        //guildObj.GetComponent<UIPopupTween>().OpenTween();

        if (isReserveElemReset == true)
        {
            isReserveElemReset = false;

            for (int i = 0; i < this.elemClassList.Count; i++)
            {
                this.elemClassList[i].Deactivate_Func();
            }

            for (int i = 0; i < 3; i++)
            {
                this.GenerateElem_Func();
            }
        }

        this.SelectedElem_Func(this.elemClassList[0]);

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.Guild_Activate);

        TimeSystem_Manager.Instance.Pause_Func();
    }
    private void GenerateElem_Func()
    {
        HireHeroElem_Script.HeroData _heroData;
        HeroType _heroType = this.getHeroTypeRandomClass.GetType_Func();
        _heroData.heroType = _heroType;
        _heroData.heroName = DataBase_Manager.Instance.hero.GetHeroName_Func(_heroType);

        GenerateHero.HeroData _generateHeroData = generateHeroClass.GetGenerateHeroData_Func();
        _heroData.heroLevel = _generateHeroData.heroLevel;
        _heroData.hireCost = _generateHeroData.hireCost;

        HireHeroElem_Script _hireHeroElemClass = this.poolingSystem.GetComponent_Func();
        _hireHeroElemClass.transform.SetParent(elemGroupTrf);
        _hireHeroElemClass.Activate_Func(_heroData);

        elemClassList.AddNewItem_Func(_hireHeroElemClass);
    }
    public void SelectedElem_Func(HireHeroElem_Script _elemClass)
    {
        this.whichOneClass.Selected_Func(_elemClass);

        Resume_Script.HeroData heroData;
        HeroType _heroType = _elemClass.heroType;
        heroData.heroType = _heroType;
        heroData.job = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).job;
        heroData.heroName = _elemClass.heroName;
        heroData.heroDesc = "";
        heroData.hireCost = _elemClass.hireCost;
        heroData.herolevel = _elemClass.heroLevel;
        heroData.isHirable = _elemClass.isHirable;

        this.resumeClass.Activate_Func(heroData);
    }
    public void DeactivateElem_Func(HireHeroElem_Script _elemClass)
    {
        this.elemClassList.Remove_Func(_elemClass);

        this.poolingSystem.Return_Func(_elemClass, false);
    }

    public void SelectedMarkMove_Func(bool _isDown)
    {
        HireHeroElem_Script _selectedClass = this.whichOneClass.GetWhichOne_Func();
        int _selectedID = this.elemClassList.IndexOf(_selectedClass);
        int _nextSelectedID = _selectedID;
        if(_isDown == true)
        {
            _nextSelectedID++;
            _nextSelectedID %= this.elemClassList.Count;
        }
        else
        {
            _nextSelectedID--;

            if(_nextSelectedID < 0)
            {
                _nextSelectedID = this.elemClassList.Count - 1;
            }
        }

        HireHeroElem_Script _nextElem = this.elemClassList[_nextSelectedID];
        this.SelectedElem_Func(_nextElem);
    }

    public void HiredselectedHero_Func()
    {
        HireHeroElem_Script _selectedElemClass = this.whichOneClass.GetWhichOne_Func();

        if(_selectedElemClass.isHirable == true)
        {
            int _hireCost = _selectedElemClass.hireCost;

            if (UserSystem_Manager.Instance.TryControlResource_Func(UserSystem_Manager.ResourceControlType.Cost, _hireCost) == true)
            {
                UserSystem_Manager.HireHeroData _hireHeroData;
                _hireHeroData.heroType = _selectedElemClass.heroType;
                _hireHeroData.heroName = _selectedElemClass.heroName;
                _hireHeroData.heroLevel = _selectedElemClass.heroLevel;
                UserSystem_Manager.Instance.HireHero_Func(_hireHeroData);

                this.resumeClass.Hired_Func();

                _selectedElemClass.SetSoldOut_Func();
            }
        }
    }

    public void Deactivate_Func()
    {
    //guildObj.GetComponent<UIPopupTween>().CloseTween();
        guildObj.SetActive(false);

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.MainField);
    }

    private void CallDel_DayPass_Func(int _currentDay)
    {
        if(isReserveElemReset == false)
            isReserveElemReset = (_currentDay % this.guildElemResetDayCondition) == 0;
    }
    public void CallBtn_Exit_Func()
    {
        this.Deactivate_Func();
    }

    private class GetHeroTypeRandom
    {
        HeroType[] heroTypeArr;

        public GetHeroTypeRandom()
        {
            this.heroTypeArr = new HeroType[] { HeroType.Nun, HeroType.Barbarian, HeroType.Pirate, HeroType.PirateW, HeroType.Priest };
        }

        public HeroType GetType_Func()
        {
            return this.heroTypeArr.GetRandItem_Func();
        }
    }

    [System.Serializable]
    private class GenerateHero
    {
        public int generateMaxLevel;
        public float generateLevelMin;
        public float generateLevelMax;
        public float generateCostMin;
        public float generateCostMax;
        public int reviseCost;

        public HeroData GetGenerateHeroData_Func()
        {
            HeroData _heroData;

            int _maxDay = TimeSystem_Manager.Instance.MaxDay;
            int _currentDay = TimeSystem_Manager.Instance.CurrentDay;
            float _dayProgressRate = (float)_currentDay / (float)_maxDay;

            int _heroLevel = (int)((this.generateMaxLevel * _dayProgressRate) * Random.Range(this.generateLevelMin, this.generateLevelMax));

            if (_heroLevel <= 0)
                _heroLevel = 1;
            else if (generateMaxLevel < _heroLevel)
                _heroLevel = generateMaxLevel;

            _heroData.heroLevel = _heroLevel;

            int _cost = (int)(_heroLevel * Random.Range(this.generateCostMin, this.generateCostMax) * this.reviseCost);
            _heroData.hireCost = _cost;

            return _heroData;
        }

        public struct HeroData
        {
            public int heroLevel;
            public int hireCost;
        }
    }
}
