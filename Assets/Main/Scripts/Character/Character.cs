using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character
{
    #region Variables

    public CharacterJob Job; // 직업 (enum)
    public string Name; // 이름
    public int Level; // 레벨
    public int Strength; // 힘
    public int Agility; // 민첩
    public int Intelligence; // 지능

    public int Stress; // 스트레스
    public int Cost; // 고용비용

    public Resume resume;

    #endregion

    #region sprite

    public Sprite Portrait; // 초상화
    public Sprite Torso; // 흉상

    #endregion

    // Dummy Constructor
    public Character()
    {

    }
    public Character(string name, Sprite portrait)
    {
        Name = name;
        Portrait = portrait;
    }
    public Character(string name, Sprite portrait, int stress, int level, int cost)
    {
        Name = name;
        Portrait = portrait;
        Stress = stress;
        Level = level;
        Cost = cost;
    }

    // Generation Constructor


}
