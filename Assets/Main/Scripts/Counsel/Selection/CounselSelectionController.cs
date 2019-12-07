using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class CounselSelectionController : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI textUi;
    public UnityAction<int> mouseDownEvent;

    public void OnClick()
    {
        Debug.Log("!");

        if (mouseDownEvent != null)
            mouseDownEvent(index);

        Debug.Log("?");
    }

    public void UpdateText(string text, UnityAction<int> callback)
    {
        this.textUi.text = text;
        mouseDownEvent = callback;
    }
}
