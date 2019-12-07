﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using static FieldDungeon_Script;

public class FieldSystem_Manager : MonoBehaviour
{
    public static FieldSystem_Manager Instance;

    [SerializeField] private Transform[] dungeonSpawnPosTrfArr;
    [SerializeField] private GameObject fieldIconObj;
    private PoolingSystem<FieldDungeon_Script> poolingSystem;

    private List<FieldDungeon_Script> fieldDungeonList;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;

            poolingSystem = new PoolingSystem<FieldDungeon_Script>();
            poolingSystem.Init_Func(this.transform, fieldIconObj, 5);

            fieldDungeonList = new List<FieldDungeon_Script>();
        }
        else if(_layer == 1)
        {
            TimeSystem_Manager.Instance.Subscribe_Func(CallDel_TimeRunning_Func);
            TimeSystem_Manager.Instance.Subscribe_DayPass_Func(CallDel_PassDay_Func);
        }
        
        yield break;
    }

    public void Activate_Func()
    {
        StartCoroutine(GenerateDungeon_Cor());
    }

    private IEnumerator GenerateDungeon_Cor()
    {
        while (true)
        {
            if(false)
            {

            }

            yield return null;
        }
    }

    public void SelectedIcon_Func(FieldIcon_Script _fieldIconClass)
    {
        switch (_fieldIconClass.FieldIconType)
        {
            case FieldIconType.Guild:
                GuildSystem_Manager.Instance.Activate_Func();
                break;

            case FieldIconType.Dungeon:
                break;

            case FieldIconType.Boss:
                break;

            default:
                break;
        }
    }

    public void TimeOutDungeon_Func(FieldDungeon_Script _fieldDungeonClass)
    {
        this.fieldDungeonList.Remove_Func(_fieldDungeonClass);

        this.poolingSystem.Return_Func(_fieldDungeonClass);
    }
    public void CallDel_PassDay_Func(int _currentDay)
    {
        if (Random_C.CheckPercent_Func(2) == false) return;

        int _maxDay = TimeSystem_Manager.Instance.MaxDay;

        DataBase_Manager.Dungeon _dungeonClass = DataBase_Manager.Instance.dungeon;

        DataBase_Manager.Dungeon.LevelData _selectedlevelData = new DataBase_Manager.Dungeon.LevelData();
        foreach (DataBase_Manager.Dungeon.LevelData _levelData in _dungeonClass.levelDataArr)
        {
            if(_currentDay < _levelData.needDay)
            {
                _selectedlevelData = _levelData;
                break;
            }
        }

        DungeonLevel _dungeonLevel = DungeonLevel.VeryHard;
        for (int i = 0; i < _selectedlevelData.levelPerArr.Length; i++)
        {
            int _levelPer = _selectedlevelData.levelPerArr[i];
            
            if(Random_C.CheckPercent_Func(_levelPer) == true)
            {
                _dungeonLevel = (DungeonLevel)(i + 1);
                break;
            }
        }

        FieldDungeon_Script _fieldDungeonClass = this.poolingSystem.GetComponent_Func();
        FieldDungeon_Script.DungeonData _dungeonData;
        _dungeonData.dungeonLevel = _dungeonLevel;

        int _dungeonLevelID = (int)_dungeonLevel;
        float _levelRewardBonus = DataBase_Manager.Instance.dungeon.levelRewardBonusArr[_dungeonLevelID];
        int _rewardDefault = DataBase_Manager.Instance.dungeon.rewardDefault;
        float _rewardMulti = DataBase_Manager.Instance.dungeon.rewardMulti;
        float _rewardReviseMin = DataBase_Manager.Instance.dungeon.rewardReviseMin;
        float _rewardReviseMax = DataBase_Manager.Instance.dungeon.rewardReviseMax;
        _dungeonData.rewardMin = (int)(_currentDay * _rewardMulti * _rewardReviseMin * _levelRewardBonus) + _rewardDefault;
        _dungeonData.rewardMax = (int)(_currentDay * _rewardMulti * _rewardReviseMax * _levelRewardBonus) + _rewardDefault;
        _dungeonData.stressMin = 10;
        _dungeonData.stressMax = 30;
        _dungeonData.passDayMin = 3;
        _dungeonData.passDayMax = 5;
        _dungeonData.lastTime = DataBase_Manager.Instance.dungeon.dungeonLastTime;
        
        _fieldDungeonClass.Activate_Func(_dungeonData);
    }

    private void CallDel_TimeRunning_Func(float _runningTime)
    {
        foreach (FieldDungeon_Script _fieldDungeonClass in fieldDungeonList)
        {
            _fieldDungeonClass.TimeRunning_Func(_runningTime);
        }
    }

    public enum FieldIconType
    {
        Guild,
        Dungeon,
        Boss,
    }
}
