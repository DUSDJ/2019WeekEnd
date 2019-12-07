using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public interface IDungeonResultHeroSlot
{
    void SetHeroData(ICharacter hero, FieldDungeon_Script.IDungeonReseultDataBus resultData);
}

public class DungeonResultHeroSlot : MonoBehaviour, IDungeonResultHeroSlot
{
    public ICharacter heroData;

    public Image heroIcon;
    public TextMeshProUGUI heroNameText;
    public TextMeshProUGUI heroLevelText;
    public TextMeshProUGUI heroStressText;

    public void SetHeroData(ICharacter hero, FieldDungeon_Script.IDungeonReseultDataBus resultData)
    {
        heroData = hero;
        heroIcon.sprite = hero.GetIcon();
        heroNameText.text = hero.GetName();
        heroLevelText.text = string.Format("Lv. {0} > Lv. {1}", hero.GetLevel() - 1, hero.GetLevel());

        if (resultData == null)
            return;

        heroStressText.text = string.Format("스트레스 : {0} > {1}", hero.GetStress(), hero.GetStress()
            + resultData.GetStress());
    }
}
