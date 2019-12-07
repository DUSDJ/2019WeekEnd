using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.Observer;
using System;

public class UserSystem_Manager : MonoBehaviour
{
    public static UserSystem_Manager Instance;

    private List<UserHeroData> userHeroDataList;
    private int haveGold;
    private Observer_Action<int> haveGoldObserver;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;

            userHeroDataList = new List<UserHeroData>();

            haveGoldObserver = new Observer_Action<int>();
        }
        else if(_layer == 1)
        {
            int _startGold = DataBase_Manager.Instance.test.startGold;
            this.haveGold = _startGold;

            UI_Bottom_Resource_Manager.Instance.SetGold_Func(_startGold);
        }

        yield break;
    }

    public void HireHero_Func(HireHeroData _hireHeroData)
    {
        UserHeroData _userHeroData = new UserHeroData();
        _userHeroData.heroType = _hireHeroData.heroType;
        _userHeroData.heroName = _hireHeroData.heroName;
        _userHeroData.heroLevel = _hireHeroData.heroLevel;

        this.userHeroDataList.AddNewItem_Func(_userHeroData);
    }

    public bool TryControlResource_Func(ResourceControlType _resourceControl, int _value, bool _isJustCheck = false)
    {
        bool _isReturn = false;

        if(_resourceControl == ResourceControlType.Earn)
        {
            this.haveGold += _value;

            _isReturn = true;
        }
        else
        {
            if(_value <= this.haveGold)
            {
                if(_isJustCheck == false)
                {
                    this.haveGold -= _value;
                }

                _isReturn = true;
            }
            else
            {
                _isReturn = false;
            }
        }

        if (_isReturn == true)
            this.haveGoldObserver.Notify_Func(this.haveGold);

        return _isReturn;
    }

    public void Subscribe_Func(Action<int> _del)
    {
        this.haveGoldObserver.Subscribe_Func(_del);
    }
    public void Remove_Func(Action<int> _del)
    {
        this.haveGoldObserver.Remove_Func(_del);
    }

    public enum ResourceControlType
    {
        Earn,
        Cost,
    }

    public struct HireHeroData
    {
        public HeroType heroType;
        public string heroName;
        public int heroLevel;
    }
}

public class UserHeroData
{
    public HeroType heroType;
    public string heroName;
    public int heroLevel;
}