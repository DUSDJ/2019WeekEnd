using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireManager : MonoBehaviour
{
    public List<Character> WaitingCharacters;
    public Dictionary<CharacterJob, List<string>> NameDic;
    public int MaxWaitingHero = 3;

    private HireSlot selectedSlot;
    public HireSlot SelectedSlot
    {
        set
        {
            selectedSlot = value;

            if (value == null)
            {
                return;
            }
            GameManager.Instance.HouseManager.UpdateHireResume(value.chara);
        }
        get { return selectedSlot; }
    }
    public HireSlot isClicked;

    // Start is called before the first frame update
    void Start()
    {
        WaitingCharacters = new List<Character>();
        NameDic = new Dictionary<CharacterJob, List<string>>();


        /* Sample Init */
        Init();
        Reroll();
    }

    public void Init()
    {
        /* DB 읽어서 직업 맞춰 이름 저장해야 함 */
        List<string> nameList = new List<string>();
        nameList.Add("크로아딘1");
        nameList.Add("크로아딘2");
        nameList.Add("크로아딘3");
        nameList.Add("크로아딘4");
        nameList.Add("크로아딘5");
        NameDic.Add((CharacterJob)0, nameList);

        nameList = new List<string>();
        nameList.Add("아케이니스1");
        nameList.Add("아케이니스2");
        nameList.Add("아케이니스3");
        nameList.Add("아케이니스4");
        nameList.Add("아케이니스5");
        NameDic.Add((CharacterJob)1, nameList);

        nameList = new List<string>();
        nameList.Add("조니 뎁1");
        nameList.Add("조니 뎁2");
        nameList.Add("조니 뎁3");
        nameList.Add("조니 뎁4");
        nameList.Add("조니 뎁5");
        NameDic.Add((CharacterJob)2, nameList);

        nameList = new List<string>();
        nameList.Add("스완1");
        nameList.Add("스완2");
        nameList.Add("스완3");
        nameList.Add("스완4");
        nameList.Add("스완5");
        NameDic.Add((CharacterJob)3, nameList);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Reroll();
        }
    }

    public Character CharaGenerator()
    {
        /* Job Random */
        int r = Random.Range(0, System.Enum.GetValues(typeof(CharacterJob)).Length - 1);
        
        Character chara = new Character();
        CharacterJob job = (CharacterJob)r;
        chara.Job = job;

        Debug.Log(job.ToString());

        List<string> nameList = NameDic[job];
        r = Random.Range(0, nameList.Count - 1);
        chara.Name = nameList[r];

        // Sprite Set
        Sprite portrait = Resources.Load<Sprite>("Sprites/"+ job.ToString() + "Portrait");
        Sprite torso = Resources.Load<Sprite>("Sprites/" + job.ToString() + "Torso");
        chara.Portrait = portrait;
        chara.Torso = torso;

        /* cost 공식은 아직*/
        int cost = Random.Range(10, 30);
        chara.Cost = cost;
        /* 능력치 */
        int strength = Random.Range(1, 60);
        chara.Strength = strength;
        int intelligence = Random.Range(1, 60);
        chara.Intelligence = intelligence;
        int agility = Random.Range(1, 60);
        chara.Agility = agility;

        int level = Random.Range(1, 3);
        chara.Level = level;
        int stress = Random.Range(0, 50);
        chara.Stress = stress;

        return chara;
    }

    

    public void Reroll()
    {
        WaitingCharacters = new List<Character>();

        for(int i=0; i< MaxWaitingHero; i++)
        {
            WaitingCharacters.Add(CharaGenerator());
        }
    }

    public void HireButton()
    {
        if (GameManager.Instance.HeroManager.AddHero(selectedSlot.chara))
        {
            WaitingCharacters.Remove(selectedSlot.chara);
            GameManager.Instance.HouseManager.UpdateHireMenu();

            selectedSlot.HighLight.SetActive(false);
            selectedSlot = null;
            isClicked = null;
            GameManager.Instance.HouseManager.InitHireResume();
        }
        else
        {
            Debug.Log("No Gold");
        }

    }
}
