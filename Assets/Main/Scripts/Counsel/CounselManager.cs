using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CounselData
{
    public string Title;
    public string Body;
    public string[] Selections;
}

public class CounselManager : MonoBehaviour
{
    public Character nowSelectedHero;

    public CounselData[] counselDatabase;
    public CounselController counselController;

    public CounselView counselView;
    
    public void Awake()
    {
        ShowCounsel();
    }

    public void ShowCounsel()
    {
        int counselIndex = Random.Range(0, counselDatabase.Length);
        CounselModel model = RetrieveCounselModelOnDatabase(counselIndex);

        counselController = new CounselController(model, counselView);

        counselController.UpdateView();

        // 등장 연출        
    }

    public CounselModel RetrieveCounselModelOnDatabase(int index)
    {
        CounselModel model = new CounselModel();

        model.Title = counselDatabase[index].Title;
        model.Body = counselDatabase[index].Body;
        model.Selections = counselDatabase[index].Selections;

        model.Hero = nowSelectedHero;

        return model;
    }
}
