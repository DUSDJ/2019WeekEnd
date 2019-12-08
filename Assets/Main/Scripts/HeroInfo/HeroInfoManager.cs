using UnityEngine;
using System.Collections;

public class HeroInfoManager : Singleton<HeroInfoManager>
{
    public ICharacter nowSelectedHero;

    public HeroInfoController heroInfoController;
    public CounselManager counselManager;

    public GameObject heroInfoPanel;
    public HeroInfoView heroInfoView;
    public Animation counselAni;

    public void Show(ICharacter hero)
    {
        nowSelectedHero = hero;

        heroInfoPanel.SetActive(true);

        HeroInfoModel model = RetrieveHeroInfoModelOnDatabase();

        heroInfoController = new HeroInfoController(model, heroInfoView);
        heroInfoController.UpdateView();

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.HeroInfo_Activate);
    }

    public void Hide()
    {
        nowSelectedHero = null;

        heroInfoPanel.SetActive(false);

        UI_HeroList_Manager.Instance.DeselectedElem_Func();

        UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.MainField);

        //UserControlSystem_Manager.ControlState _currentControlState = UserControlSystem_Manager.Instance.CurrentControlState;
        //if(_currentControlState == UserControlSystem_Manager.ControlState.Guild_Activate)
        //{

        //}
        //else
        //{
        //    UserControlSystem_Manager.Instance.SetState_Func(UserControlSystem_Manager.ControlState.MainField);
        //}
    }

    public void ShowCounsel()
    {
        counselManager.ShowCounsel(nowSelectedHero);

        counselAni.Play_Func(counselAni.clip);
    }

    public HeroInfoModel RetrieveHeroInfoModelOnDatabase()
    {
        HeroInfoModel model = new HeroInfoModel();

        model.Hero = nowSelectedHero;

        return model;
    }
}
