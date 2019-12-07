using UnityEngine;
using TMPro;
using System.Collections;

public class CounselSelectionController : MonoBehaviour
{
    public TextMeshProUGUI textUi;

    public void OnMouseDown()
    {
    }

    public void UpdateText(string text)
    {
        this.textUi.text = text;
    }
}
