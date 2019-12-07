using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Collections;

public class HeroInfoView : MonoBehaviour
{
    public TextMeshProUGUI heroJob;
    public TextMeshProUGUI heroLevel;
    public TextMeshProUGUI heroName;

    public Image[] statusGauses;

    public TextMeshProUGUI stressValue;
    public Image stressGauses;

    public TextMeshProUGUI karmaTexts;

    public GameObject counselButton;

    public void UpdateView(string job, int level, string heroName
        , int strengthValue, int agilityValue, int intelligenceValue, int stressValue
        , string[] karmas, bool canCounsel = false)
    {
        heroJob.text = job;
        heroLevel.text = level.ToString();
        this.heroName.text = heroName;

        statusGauses[0].fillAmount = strengthValue / 100f;
        statusGauses[1].fillAmount = agilityValue / 100f;
        statusGauses[2].fillAmount = intelligenceValue / 100f;

        this.stressValue.text = stressValue.ToString();
        stressGauses.fillAmount = stressValue / 100f;

        if (karmas != null)
        {
            StringBuilder karmaText = new StringBuilder(128);
            for (int ix = 0; ix < karmas.Length; ix++)
            {
                karmaText.AppendLine(karmas[ix]);
            }
            karmaTexts.text = karmaText.ToString();
        }

        counselButton.SetActive(canCounsel);

        Debug.Log("?");
    }
}
