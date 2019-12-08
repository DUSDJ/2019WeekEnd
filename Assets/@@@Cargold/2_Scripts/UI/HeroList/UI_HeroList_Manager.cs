using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using Cargold.WhichOne;

public class UI_HeroList_Manager : MonoBehaviour
{
    public static UI_HeroList_Manager Instance;

    [SerializeField] private GameObject elemObj;
    [SerializeField] private Transform elemGroupTrf;

    private PoolingSystem<UI_HeroListElem_Script> poolingSystem;
    private WhichOne<UI_HeroListElem_Script> whichOneClass;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        poolingSystem = new PoolingSystem<UI_HeroListElem_Script>();
        poolingSystem.Init_Func(this.transform, this.elemObj, 10);

        whichOneClass = new WhichOne<UI_HeroListElem_Script>();

        yield break;
    }

    public void GenerateElem_Func(UserHeroData _userHeroData)
    {
        UI_HeroListElem_Script _elemClass = poolingSystem.GetComponent_Func();
        _elemClass.transform.SetParent(elemGroupTrf);
        _elemClass.Activate_Func(_userHeroData);
    }

    public void SelectedElem_Func(UI_HeroListElem_Script _elemClass)
    {
        this.whichOneClass.Selected_Func(_elemClass);

        UserControlSystem_Manager.ControlState _currentControlState = UserControlSystem_Manager.Instance.CurrentControlState;

        if(_currentControlState == UserControlSystem_Manager.ControlState.Dungeon_SlotSelected)
        {
            DungeonInfoView.Instance.SetHeroData(_elemClass);

            _elemClass.SetState_Expedition_Func(UI_HeroListElem_Script.ElemExpeditionState.Arrangement);
        }
        else
        {
            HeroInfoManager.Instance.Show(_elemClass);

            //HeroType _heroType = _elemClass.UserHeroData.heroType;
            //string _job = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).job;
            //int _level = _elemClass.UserHeroData.heroLevel;
            //string _heroName = _elemClass.UserHeroData.heroName;
            //int _str = _elemClass.UserHeroData.strength;
            //int _agi = _elemClass.UserHeroData.agility;
            //int _int = _elemClass.UserHeroData.intelligence;
            //int _stress = _elemClass.UserHeroData.stressPoint;
            //string[] _karmaArr = new string[] { "김대도 바보", "Karma1", "Cargold Is God" };  

            //HeroInfoView.Instance.UpdateView(_job, _level, _heroName, _str, _agi, _int, _stress, _karmaArr);
        }
    }

    public void DeselectedElem_Func()
    {
        whichOneClass.SelectCancel_Func();
    }
}
