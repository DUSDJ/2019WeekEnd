using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Collections;

public class HeroInfoView : MonoBehaviour
{
    public static HeroInfoView Instance;

    public Image torsoImg;

    public TextMeshProUGUI heroJob;
    public TextMeshProUGUI heroLevel;
    public TextMeshProUGUI heroName;

    public Image[] statusGauses;

    public TextMeshProUGUI stressValue;
    public Image stressGauses;

    public TextMeshProUGUI karmaTexts;

    public GameObject counselButton;
    
    public IEnumerator Init_Cor()
    {
        Instance = this;

        this.Deativate_Func(true);

        yield break;
    }

    public void UpdateView(HeroType _heroType, int level, string heroName
        , int strengthValue, int agilityValue, int intelligenceValue, int stressValue
        , string[] karmas, bool canCounsel = false)
    {
        this.gameObject.SetActive(true);
        
        Sprite _heroSprite = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).torsoSprite;
        torsoImg.sprite = _heroSprite;

        heroJob.text = DataBase_Manager.Instance.hero.heroDataDic.GetValue_Func(_heroType).job;
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
    }
    
    public void Deativate_Func(bool _isInit = false)
    {
        this.gameObject.SetActive(false);
    }

    public void CallBtn_Close_Func()
    {
        this.Deativate_Func();
    }
}
