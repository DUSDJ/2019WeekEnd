using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CounselView : MonoBehaviour
{
    public Image background;
    public Image portrait;

    public Image[] lines;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public CounselSelectionController[] selectionControllers;
    
    public void UpdateView(string title, string body, string selection1, string selection2)
    {
        this.title.text = title;
        this.body.text = body;
        this.selectionControllers[0].UpdateText(selection1);
        this.selectionControllers[1].UpdateText(selection2);
    }
}
