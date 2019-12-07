using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DungeonInfoView : MonoBehaviour
{
    public TextMeshProUGUI dungeonLevelText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI stressText;
    public TextMeshProUGUI passDayText;

    public TextMeshProUGUI averageStressText;

    public RectTransform averageStressIndicator;
    public Vector2 averageStressIndicatorMinPosition = new Vector2(0, 20),
        averageStressIndicatorMaxPosition = new Vector2(312, 20);

    public GameObject speechBubble;
    public TextMeshProUGUI speechBubbleText;

    public GameObject[] dungeonSlots;

    // 1, 5, 10, 15, 20
    public string[] dungeonLevels = new string[5]{"매우 쉬움", "쉬움", "보통", "어려움", "매우 어려움" };
    public string[] speechs = new string[5]
    {
        "너무 과한 투자가 아닐까 싶습니다.",
        "단원들이 모두 걱정없이 돌아 오겠군요.",
        "이보다 좋은 팀은 없을겁니다.",
        "단원들에겐 큰 시련이 될 듯 합니다.",
        "단장님은 단원들을 사지로 몰 생각입니까?"
    };

    public void UpdateView(FieldDungeon_Script.DungeonData dungeonData)
    {
        dungeonLevelText.text = dungeonLevels[(int)dungeonData.dungeonLevel];
        rewardText.text = string.Format(dungeonData.rewardMin + "\n-\n" + dungeonData.rewardMax);
        stressText.text = string.Format(dungeonData.stressMin + "\n-\n" + dungeonData.stressMax);
        passDayText.text = string.Format(dungeonData.passDayMin + "일\n-\n" + dungeonData.passDayMax + "일");

        averageStressText.text = string.Format("원정대 평균스트레스 0%");
        averageStressIndicator.anchoredPosition = averageStressIndicatorMinPosition;

        for (int ix = 0; ix < dungeonSlots.Length; ix++)
            dungeonSlots[ix].GetComponent<IDungeonSlot>().SetHeroData(null);

        speechBubble.SetActive(false);

        selectedSlot = null;
    }

    public void UpdateAverageStress()
    {
        float totalStress = 0f;
        int heroCountOnSlot = 0;
        int totalLevel = 0;
        for (int ix = 0; ix < dungeonSlots.Length; ix++)
        {
            ICharacter temp = dungeonSlots[ix].GetComponent<IDungeonSlot>().GetHeroData();
            if (temp == null)
                continue;

            heroCountOnSlot++;
            totalStress += temp.GetStress();
            totalLevel += temp.GetLevel();
        }

        int averageStress = (int)(totalStress / heroCountOnSlot);
        averageStressText.text = string.Format("원정대 평균스트레스 {0}%", averageStressText);
        averageStressIndicator.anchoredPosition =
            Vector2.Lerp(averageStressIndicatorMinPosition, averageStressIndicatorMaxPosition, averageStress / 100f);

        int averageLevel = (int)(totalLevel / heroCountOnSlot);
        int levelGrade = (int)(averageLevel / speechs.Length);

        speechBubble.SetActive(true);
        speechBubbleText.text = speechs[levelGrade];
    }

    public DungeonSlot selectedSlot;

    public void SetSelectedSlot(DungeonSlot slot)
    {
        selectedSlot = slot;
        for (int ix = 0; ix < dungeonSlots.Length; ix++)
        {
            if (dungeonSlots[ix].GetComponent<DungeonSlot>() == slot)
            {
                dungeonSlots[ix].GetComponent<DungeonSlot>().isSelected = true;
                continue;
            }

            dungeonSlots[ix].GetComponent<DungeonSlot>().isSelected = false;
        }
    }

    public void SetHeroData(ICharacter hero)
    {
        if (selectedSlot != null)
            selectedSlot.SetHeroData(hero);
    }
}
