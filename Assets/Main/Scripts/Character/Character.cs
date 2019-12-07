using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//[Serializable]
//public class ICharacter
//{
//    #region Variables

//    private CharacterJob job; // 직업 (enum)
//    private string name; // 이름
//    private int level; // 레벨
//    private int strength; // 힘
//    private int agility; // 민첩
//    private int intelligence; // 지능

//    public int Stress; // 스트레스
//    public int Cost; // 고용비용

//    private bool needCounsel = false;

//    public Resume resume;

//    #endregion

//    #region sprite

//    public Sprite Portrait; // 초상화
//    public Sprite Torso; // 흉상

//    public CharacterJob GetJob()
//    {
//        return job;
//    }

//    public string GetName()
//    {
//        return name;
//    }
    
//    public int GetLevel()
//    {
//        return level;
//    }

//    public int GetStrength()
//    {
//        return strength;
//    }
    
//    public int GetAgility()
//    {
//        return agility;
//    }
    
//    public int GetIntelligence()
//    {
//        return intelligence;
//    }

//    public bool GetNeedCounsel()
//    {
//        return needCounsel;
//    }
    

//    #endregion

//    // Dummy Constructor
//    public ICharacter()
//    {

//    }
//    public ICharacter(string name, Sprite portrait)
//    {
//        SetName(name);
//        Portrait = portrait;
//    }
//    public ICharacter(string name, Sprite portrait, int stress, int level, int cost)
//    {
//        SetName(name);
//        Portrait = portrait;
//        Stress = stress;
//        SetLevel(level);
//        Cost = cost;
//    }

//    // Generation Constructor

//    public string CharacterJobToString()
//    {
//        string result = "";

//        switch (GetJob())
//        {
//            case CharacterJob.Barbarian:
//                result = "야만전사";
//                break;
//            case CharacterJob.Nun:
//                result = "북방의 여사제";
//                break;
//            case CharacterJob.Pirate:
//                result = "해적";
//                break;
//            case CharacterJob.PirateW:
//                result = "여해적";
//                break;
//            default:
//                break;
//        }

//        return result;
//    }
//}
