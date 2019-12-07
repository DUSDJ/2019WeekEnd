using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class SoundButton : MonoBehaviour
{
    string audioCilpFileName;
    public Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Play);
        audioCilpFileName = "ButtonSound";
    }

    public void Play()
    {
        SoundManager.Instance.PlaySFX(audioCilpFileName);
    }
}
