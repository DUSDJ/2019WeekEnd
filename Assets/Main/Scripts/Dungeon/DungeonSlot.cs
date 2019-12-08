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

    public bool isSelected = false;
    public DungeonSlot index;

    public ICharacter heroDataBus = null;
    public Image heroIcon;

    public ICharacter GetHeroData()
    {
        return heroDataBus;
    }

    public void OnClick()
    {
        dungeonInfomationView.SetSelectedSlot(this);
    }

    public void SetHeroData(ICharacter hero)
    {
        if (hero == null)
        {
            isSelected = false;
            heroIcon.sprite = null;
            heroIcon.gameObject.SetActive(false);
            return;
        }
        heroIcon.gameObject.SetActive(true );
        heroDataBus = hero;
        heroIcon.sprite = hero.GetIcon();

        DungeonInfoView.Instance.UpdateAverageStress();
    }
}
