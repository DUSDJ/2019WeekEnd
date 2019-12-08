using UnityEngine;
using System.Collections;

public class HeroInfoController
{
    public HeroInfoView view;
    public HeroInfoModel model;

    public HeroInfoController(HeroInfoModel model, HeroInfoView view)
    {
        this.model = model;
        this.view = view;
    }

    public void SetModel(HeroInfoModel model)
    {
        this.model = model;
    }

    public void UpdateView()
    {
        HeroType _heroType = model.Hero.GetHeroType();
        string[] _karmaArr = model.Hero.GetKarmaArr_Func();

        view.UpdateView(
            _heroType, model.Hero.GetLevel(), model.Hero.GetName(),
            model.Hero.GetStrength(), model.Hero.GetAgility(), model.Hero.GetIntelligence(), model.Hero.GetStress(),
            _karmaArr, model.Hero.GetNeedCounsel());
    }
}
