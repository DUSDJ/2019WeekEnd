using System.Collections;
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
    private GeneratePosControl[] generatePosControlArr;

    public IEnumerator Init_Cor(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;

            poolingSystem = new PoolingSystem<FieldDungeon_Script>();
            poolingSystem.Init_Func(this.transform, fieldIconObj, 5);

            fieldDungeonList = new List<FieldDungeon_Script>();

            generatePosControlArr = new GeneratePosControl[dungeonSpawnPosTrfArr.Length];
            for (int i = 0; i < generatePosControlArr.Length; i++)
            {
                generatePosControlArr[i] = new GeneratePosControl(dungeonSpawnPosTrfArr[i]);
            }
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
        GenerateDungeon_Func(1);
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

        bool _isFind = false;
        foreach (GeneratePosControl item in this.generatePosControlArr)
        {
            if (item.generateDungeon == _fieldDungeonClass)
            {
                _isFind = true;

                item.generateDungeon = null;
                break;
            }
        }
        if (_isFind == false)
            Debug_C.Error_Func("?");
    }
    public void CallDel_PassDay_Func(int _currentDay)
    {
        for (int i = 0; i < 3; i++)
        {
            if (Random_C.CheckPercent_Func(2) == true)
            {
                this.GenerateDungeon_Func(_currentDay);
            }
        }
    }

    private void GenerateDungeon_Func(int _currentDay)
    {
        GeneratePosControl _generatePosControl = null;
        for (int i = 0; i < this.generatePosControlArr.Length; i++)
        {
            if(this.generatePosControlArr[i].generateDungeon == null)
            {
                _generatePosControl = this.generatePosControlArr[i];
                break;
            }
        }

        if (_generatePosControl != null)
        {
            int _maxDay = TimeSystem_Manager.Instance.MaxDay;

            DataBase_Manager.Dungeon _dungeonClass = DataBase_Manager.Instance.dungeon;

            DataBase_Manager.Dungeon.LevelData _selectedlevelData = new DataBase_Manager.Dungeon.LevelData();
            foreach (DataBase_Manager.Dungeon.LevelData _levelData in _dungeonClass.levelDataArr)
            {
                if (_currentDay < _levelData.needDay)
                {
                    _selectedlevelData = _levelData;
                    break;
                }
            }

            DungeonLevel _dungeonLevel = DungeonLevel.VeryHard;
            for (int i = 0; i < _selectedlevelData.levelGeneratePerArr.Length; i++)
            {
                int _levelPer = _selectedlevelData.levelGeneratePerArr[i];

                if (Random_C.CheckPercent_Func(_levelPer) == true)
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
            _dungeonData.lastTime = Random.Range(DataBase_Manager.Instance.dungeon.dungeonLastTimeMin, DataBase_Manager.Instance.dungeon.dungeonLastTimeMax);
            
            Transform _pivotTrf = _generatePosControl.generatePosTrf;
            _fieldDungeonClass.transform.SetParent(_pivotTrf);
            _fieldDungeonClass.transform.localPosition = Vector3.zero;
            _fieldDungeonClass.transform.localScale = Vector3.one;
            _fieldDungeonClass.Activate_Func(_dungeonData);

            fieldDungeonList.AddNewItem_Func(_fieldDungeonClass);
            _generatePosControl.generateDungeon = _fieldDungeonClass;
        }
    }

    private void CallDel_TimeRunning_Func(float _runningTime)
    {
        FieldDungeon_Script _fieldDungeonClass = null;
        for (int i = 0; i < fieldDungeonList.Count;)
        {
            if(_fieldDungeonClass != fieldDungeonList[i])
            {
                _fieldDungeonClass = fieldDungeonList[i];
                if (_fieldDungeonClass.TryTimeRunning_Func(_runningTime) == false)
                    i++;
            }
            else
            {
                Debug_C.Error_Func("?");
            }
        }
    }

    public enum FieldIconType
    {
        Guild,
        Dungeon,
        Boss,
    }

    private class GeneratePosControl
    {
        public FieldDungeon_Script generateDungeon;
        public Transform generatePosTrf;

        public GeneratePosControl(Transform _generatePosTrf)
        {
            this.generatePosTrf = _generatePosTrf;
        }
    }
}
