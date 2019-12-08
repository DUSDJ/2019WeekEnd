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
        }
        else
        {

        }
    }
}
