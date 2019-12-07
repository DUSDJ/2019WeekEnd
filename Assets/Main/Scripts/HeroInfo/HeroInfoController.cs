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
            model.Hero.Job.ToString(), model.Hero.Level, model.Hero.Name,
            model.Hero.Strength, model.Hero.Agility, model.Hero.Intelligence, model.Hero.Stress,
            null, model.Hero.needCounsel);
    }
}
