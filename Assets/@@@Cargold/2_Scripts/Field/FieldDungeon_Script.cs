using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDungeon_Script : FieldIcon_Script, FieldDungeon_Script.IDungeonReseultDataBus
{
    [SerializeField] private FieldDungeon_View_Script viewClass;

    private DungeonLevel dungeonLevel;
    private int rewardMin, rewardMax;
    private int stressMin, stressMax;
    private int passDayMin, passDayMax;
    private float lastTime;
    private float lastTimeMax;
    private bool isExpeditionState;

    private DungeonResultData dungeonResultData;

    private UI_HeroListElem_Script[] heroListElemArr;

    public bool IsExpeditionState { get => isExpeditionState; }
    public UI_HeroListElem_Script[] HeroListElemArr { get => heroListElemArr; }

    public override void Init_Func()
    {
        base.Init_Func();

        this.viewClass.Init_Func();

        heroListElemArr = null;
    }

    public void Activate_Func(DungeonData _dungeonData)
    {
        isExpeditionState = false;
        heroListElemArr = null;

        this.viewClass.Activate_Func();

        this.dungeonLevel = _dungeonData.dungeonLevel;
        this.rewardMin = _dungeonData.rewardMin;
        this.rewardMax = _dungeonData.rewardMax;
        this.stressMin = _dungeonData.stressMin;
        this.stressMax = _dungeonData.stressMax;
        this.passDayMin = _dungeonData.passDayMin;
        this.passDayMax = _dungeonData.passDayMax;
        this.lastTimeMax = _dungeonData.lastTime;
        this.lastTime = _dungeonData.lastTime;
    }
    public void Expedition_Func(UI_HeroListElem_Script[] _elemClassArr)
    {
        isExpeditionState = true;
        heroListElemArr = _elemClassArr;

        float _passDayRate = Random.Range(0f, 1f);
        int _passDayResult = passDayMin + (int)((passDayMax - passDayMin) * _passDayRate);

        float _stressRate = Random.Range(0f, 1f);
        int _stressResult = stressMin + (int)((stressMax - stressMin) * _stressRate);

        float _rewardRate = Random.Range(0f, 1f);
        int _rewardResult = rewardMin + (int)((rewardMax - rewardMin) * _rewardRate);

        dungeonResultData.dungeonLevel = this.dungeonLevel;
        dungeonResultData.passDay = _passDayResult;
        dungeonResultData.stress = _stressResult;
        dungeonResultData.reward = _rewardResult;

        viewClass.SetExpeditionState_Func();

        float _lastTime = _passDayResult * DataBase_Manager.Instance.test.dayPassTime;
        this.lastTimeMax = _lastTime;
        this.lastTime = _lastTime;
        viewClass.SetTimer_Func(1f);
    }
    public bool TryTimeRunning_Func(float _runningTime)
    {
        this.lastTime -= _runningTime;

        if(0f < this.lastTime)
        {
            viewClass.SetTimer_Func(this.lastTime / this.lastTimeMax);

            return false;
        }
        else
        {
            this.Deactivate_Func();

            return true;
        }
    }
    public override void CallBtn_Selected_Func()
    {
        if(isExpeditionState == false)
            base.CallBtn_Selected_Func();
    }

    public void Deactivate_Func()
    {
        viewClass.Deactivate_Func();

        FieldSystem_Manager.Instance.TimeOutDungeon_Func(this);
    }

    public DungeonData GetDungeonData_Func()
    {
        DungeonData _dungeonData;

        _dungeonData.dungeonLevel = this.dungeonLevel;
        _dungeonData.rewardMin = this.rewardMin;
        _dungeonData.rewardMax = this.rewardMax;
        _dungeonData.stressMin = this.stressMin;
        _dungeonData.stressMax = this.stressMax;
        _dungeonData.passDayMin = this.passDayMin;
        _dungeonData.passDayMax = this.passDayMax;
        _dungeonData.lastTime = 0f;

        return _dungeonData;
    }

    public DungeonResultData GetDungeonResultData_Func()
    {
        return this.dungeonResultData;
    }

    public int GetResultStress()
    {
        return this.dungeonResultData.stress;
    }

    public interface IDungeonDataBus
    {
        DungeonData GetDungeonData();
    }

    public struct DungeonResultData
    {
        public DungeonLevel dungeonLevel;
        public int reward;
        public int stress;
        public int passDay;
    }

    public interface IDungeonReseultDataBus
    {
        DungeonResultData GetDungeonResultData_Func();
        int GetResultStress();
    }

    public struct DungeonData
    {
        public DungeonLevel dungeonLevel;
        public int rewardMin, rewardMax;
        public int stressMin, stressMax;
        public int passDayMin, passDayMax;
        public float lastTime;
    }

    public enum DungeonLevel
    {
        VeryEasy = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3,
        VeryHard = 4,
    }
}
