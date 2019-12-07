﻿using UnityEngine;
using System.Collections;

public class HeroInfoManager : MonoBehaviour
{
    public Character nowSelectedHero;

    public HeroInfoController heroInfoController;
    public CounselManager counselManager;

    public GameObject heroInfoPanel;
    public HeroInfoView heroInfoView;

    public void Show(Character hero)
    {
        nowSelectedHero = hero;

        heroInfoPanel.SetActive(true);

        HeroInfoModel model = RetrieveHeroInfoModelOnDatabase();

        heroInfoController = new HeroInfoController(model, heroInfoView);
        heroInfoController.UpdateView();

        Debug.Log("?");
    }

    public void Hide()
    {
        nowSelectedHero = null;

        heroInfoPanel.SetActive(false);
    }

    public void ShowCounsel()
    {
        counselManager.ShowCounsel(nowSelectedHero);
    }

    public HeroInfoModel RetrieveHeroInfoModelOnDatabase()
    {
        HeroInfoModel model = new HeroInfoModel();

        model.Hero = nowSelectedHero;

        return model;
    }
}