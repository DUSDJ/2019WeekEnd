using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public interface IDungeonSlot
{
    void SetHeroData(ICharacter hero);
    ICharacter GetHeroData();
}

public class DungeonSlot : MonoBehaviour, IDungeonSlot
{
    public DungeonInfoView dungeonInfomationView;

    public ICharacter heroDataBus = null;
    public Image heroIcon;

    public ICharacter GetHeroData()
    {
        return heroDataBus;
    }

    public void SetHeroData(ICharacter hero)
    {
        heroDataBus = hero;
        heroIcon.sprite = hero.GetIcon();
        
        DungeonInfoController.UpdateAverageStress();
    }
}
