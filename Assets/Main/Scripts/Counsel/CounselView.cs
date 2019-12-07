using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CounselView : MonoBehaviour
{
    public Image background;
    public Image portrait;
    public RectMask2D portraitMask;

    public Image[] lines;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public CounselSelectionController[] selectionControllers;


    public void UpdateView(string title, string body, string selection1, string selection2,
        UnityAction<int> callback, string selection3 = null)
    {
        this.title.text = title;
        this.body.text = body;

        if (selection1 != null)
            this.selectionControllers[0].UpdateText(selection1, callback);
        else
            this.selectionControllers[0].gameObject.SetActive(false);

        if (selection2 != null)
            this.selectionControllers[1].UpdateText(selection2, callback);
        else
            this.selectionControllers[1].gameObject.SetActive(false);

        if (selection3 != null)
            this.selectionControllers[2].UpdateText(selection3, callback);
        else
            this.selectionControllers[2].gameObject.SetActive(false);


        portraitMask.enabled = false;
    }
}
