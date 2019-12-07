using UnityEngine;
using System.Collections;

public class CounselController
{
    public CounselView view;
    public CounselModel model;

    public CounselController(CounselModel model, CounselView view)
    {
        this.model = model;
        this.view = view;
    }

    public void SetModel(CounselModel model)
    {
        this.model = model;
    }

    public void UpdateView()
    {
        view.UpdateView(model.Title, model.Body, model.Selections[0], model.Selections[1]
            , UpdateCharacter);
    }

    public void UpdateCharacter(int selectionIndex)
    {
        switch (model.SelectionParams[selectionIndex].parameterType)
        {
            case ParameterType.StressIncrease:
                model.Hero.Stress += model.SelectionParams[selectionIndex].parameterValue;
                break;

            case ParameterType.StressDecrease:
                model.Hero.Stress -= model.SelectionParams[selectionIndex].parameterValue;
                break;
        }
    }
}
