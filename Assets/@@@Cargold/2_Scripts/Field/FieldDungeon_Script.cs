using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDungeon_Script : FieldIcon_Script
{
    [SerializeField] private FieldDungeon_View_Script viewClass;

    private DungeonLevel dungeonLevel;
    private int rewardMin, rewardMax;
    private int stressMin, stressMax;
    private int passDayMin, passDayMax;
    private float lastTime;
    private float lastTimeMax;

    public override void Init_Func()
    {
        base.Init_Func();

        this.viewClass.Init_Func();
    }

    public void Activate_Func(DungeonData _dungeonData)
    {
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

    public void TimeRunning_Func(float _runningTime)
    {
        this.lastTime -= _runningTime;

        if(0f < this.lastTime)
        {
            viewClass.SetTimer_Func(this.lastTime / this.lastTimeMax);
        }
        else
        {

        }
    }

    public void Deactivate_Func()
    {

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
