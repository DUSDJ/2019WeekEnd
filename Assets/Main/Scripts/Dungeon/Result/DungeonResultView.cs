using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class DungeonResultView : MonoBehaviour
{
    public TextMeshProUGUI dungeonLevelText;
    public TextMeshProUGUI stressText;
    public TextMeshProUGUI passDayText;
    public TextMeshProUGUI rewardText;

    public string[] dungeonLevels = new string[5]{"매우 쉬움", "쉬움", "보통", "어려움", "매우 어려움" };

    public ICharacter[] heroDatas;
    public GameObject[] dungeonResultHeroSlots;

    public void UpdateView(FieldDungeon_Script.IDungeonReseultDataBus resultDataBus)
    {
        FieldDungeon_Script.DungeonResultData resultData = resultDataBus.GetDungeonResultData();
        dungeonLevelText.text = dungeonLevels[(int)resultData.dungeonLevel];
        stressText.text = string.Format(resultData.stress.ToString());
        passDayText.text = string.Format(resultData.passDay.ToString());
        rewardText.text = string.Format(resultData.reward.ToString());

        for (int ix = 0; ix < dungeonResultHeroSlots.Length; ix++)
        {
            dungeonResultHeroSlots[ix].GetComponent<IDungeonResultHeroSlot>().
                SetHeroData(heroDatas[ix], resultDataBus);
        }
    }

    public void ClearData()
    {
        for (int ix = 0; ix < dungeonResultHeroSlots.Length; ix++)
        {
            heroDatas[ix] = null;
            dungeonResultHeroSlots[ix].GetComponent<IDungeonResultHeroSlot>().
                SetHeroData(null, null);
        }

        gameObject.SetActive(false);
    }
}
