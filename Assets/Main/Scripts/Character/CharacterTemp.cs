using UnityEngine;
using System.Collections;

public class CharacterTemp : MonoBehaviour
{
    public HeroInfoManager heroInfoManager;
    public Character hero;

    public void OnClick()
    {
        heroInfoManager.Show(hero);
    }
}
