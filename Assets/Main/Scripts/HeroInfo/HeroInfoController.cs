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
        view.UpdateView(
            model.Hero.GetJob().ToString(), model.Hero.GetLevel(), model.Hero.GetName(),
            model.Hero.GetStrength(), model.Hero.GetAgility(), model.Hero.GetIntelligence(), model.Hero.GetStress(),
            null, model.Hero.GetNeedCounsel());
    }
}
