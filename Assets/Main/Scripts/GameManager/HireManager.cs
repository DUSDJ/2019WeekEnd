using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireManager : MonoBehaviour
{
    public List<Character> WaitingCharacters;
    public Dictionary<CharacterJob, List<string>> NameDic; 

    // Start is called before the first frame update
    void Start()
    {
        WaitingCharacters = new List<Character>();
        NameDic = new Dictionary<CharacterJob, List<string>>();

        /* Sample Init */
        Init();
    }

    public void Init()
    {
        List<string> nameList = new List<string>();
        nameList.Add("크로아딘1");
        nameList.Add("크로아딘2");
        nameList.Add("크로아딘3");
        nameList.Add("크로아딘4");
        nameList.Add("크로아딘5");
        NameDic.Add(CharacterJob.Job1, nameList);

        nameList = new List<string>();
        nameList.Add("아케이니스1");
        nameList.Add("아케이니스2");
        nameList.Add("아케이니스3");
        nameList.Add("아케이니스4");
        nameList.Add("아케이니스5");
        NameDic.Add(CharacterJob.Job2, nameList);

        nameList = new List<string>();
        nameList.Add("조니 뎁1");
        nameList.Add("조니 뎁2");
        nameList.Add("조니 뎁3");
        nameList.Add("조니 뎁4");
        nameList.Add("조니 뎁5");
        NameDic.Add(CharacterJob.Job3, nameList);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CharaGenerator();
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



        return chara;
    }

    public void Reroll()
    {
        WaitingCharacters = new List<Character>();

        /*
         1. 직군 중 하나를 고른다.
         2. 직군별 이름 중 하나를 고른다.
         3. 직군별 초상화, 흉상 설정
         4. 능력치 등 설정
         */

        //Character chara = new Character("Name", )
        //WaitingCharacters.Add();
    }
}
