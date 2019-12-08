﻿using UnityEngine;
using System.Collections;

public class HeroInfoModel
{
    /// <summary>
    /// 능력치, 스트레스, 이름, 레벨, 직업, 카르마, 포트레이트?
    /// </summary>
    public ICharacter Hero;
}

public interface ICharacter
{
    HeroType GetHeroType();
    string GetName();
    int GetLevel();
    int GetStrength();
    int GetAgility();
    int GetIntelligence();
    bool GetNeedCounsel();
    int GetStress();
    void AddStress(int stress);
    string[] GetKarmaArr_Func();

    Sprite GetIcon();
}