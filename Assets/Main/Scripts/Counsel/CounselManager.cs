using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CounselData
{
    public string Title;
    public string Body;
    public string[] Selections;

    public ParameterType[] counselSelectionParameterType;
    public int[] counselSelectionParameterValue;
}

public class CounselManager : MonoBehaviour
{
    public ICharacter nowSelectedHero;

    public CounselData[] counselDatabase;
    public CounselController counselController;

    public CounselView counselView;

    public void ShowCounsel(ICharacter hero)
    {
        nowSelectedHero = hero;

        int counselIndex = Random.Range(0, counselDatabase.Length);
        CounselModel model = RetrieveCounselModelOnDatabase(counselIndex);

        counselController = new CounselController(model, counselView);

        counselController.UpdateView();

        // 등장 연출        
        counselView.gameObject.SetActive(true);
    }

    public CounselModel RetrieveCounselModelOnDatabase(int index)
    {
        CounselModel model = new CounselModel();

        model.Title = counselDatabase[index].Title;
        model.Body = counselDatabase[index].Body;
        model.Selections = counselDatabase[index].Selections;

        model.SelectionParams = new CounselSelectionParameter[counselDatabase[index].Selections.Length];
        for (int ix = 0; ix < counselDatabase[index].Selections.Length; ix++)
        {
            Debug.Log(ix);
            model.SelectionParams[ix] = new CounselSelectionParameter();
            model.SelectionParams[ix].parameterType = counselDatabase[index].counselSelectionParameterType[ix];
            model.SelectionParams[ix].parameterValue = counselDatabase[index].counselSelectionParameterValue[ix];
        }

        model.Hero = nowSelectedHero;

        return model;
    }
}
