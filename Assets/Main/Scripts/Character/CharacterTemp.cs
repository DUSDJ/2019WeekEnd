using UnityEngine;
using System.Collections;

public class CharacterTemp : MonoBehaviour
{
    public HeroInfoManager heroInfoManager;
    public ICharacter hero;

    public void OnClick()
    {
        heroInfoManager.Show(hero);
    }
}
