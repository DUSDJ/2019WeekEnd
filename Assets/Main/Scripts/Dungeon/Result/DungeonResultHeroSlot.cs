using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DungeonResultHeroSlot : MonoBehaviour
{
    public Image heroIcon;
    public TextMeshProUGUI heroNameText;
    public TextMeshProUGUI heroLevelText;
    public TextMeshProUGUI heroStressText;

    public void Clear_Func()
    {
        this.gameObject.SetActive(false);
    }

    public void SetHeroData(Sprite _iconSprite, string _name, int _originLv, int _gainLv, int _originStress, int _gainStress)
    {
        this.gameObject.SetActive(true);

        heroIcon.sprite = _iconSprite;
        heroNameText.text = _name;
        heroLevelText.text = string.Format("Lv. {0} > Lv. {1}", _originLv, _originLv + _gainLv);
        heroStressText.text = string.Format("스트레스 : {0} > {1}", _originStress, _originStress + _gainStress);
    }
}
