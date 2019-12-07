using UnityEngine;
using System.Collections;

public class CounselButton : MonoBehaviour
{
    public HeroInfoManager heroInfoManager;

    public void OnClick()
    {
        heroInfoManager.ShowCounsel();
    }
}
