using Cargold.Observer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSystem_Manager : MonoBehaviour
{
    public static TimeSystem_Manager Instance;
    
    [SerializeField] private int maxDay;
    private Observer_Action<int> dayPassObserver;
    private Observer_Action<float> timeRunningObserver;
    private bool isTimeRunning;
    private float currentDayTime;
    private int currentDay;
    
    public int MaxDay { get { return maxDay; } }
    public int CurrentDay { get => currentDay; }

  public TextMeshProUGUI text;

    public IEnumerator Init_Cor()
    {
        Instance = this;

        dayPassObserver = new Observer_Action<int>();
        timeRunningObserver = new Observer_Action<float>();

        isTimeRunning = false;

        currentDayTime = DataBase_Manager.Instance.test.dayPassTime;

        currentDay = 0;
        
        yield break;
    }

    public void Activate_Func()
    {
        currentDay = 1;

        StartCoroutine(TimeRunning_Cor());
    }

    public IEnumerator TimeRunning_Cor()
    {
        while (true)
        {
            if (isTimeRunning == true)
            {
                float _deltaTime = Time.deltaTime;
                this.timeRunningObserver.Notify_Func(_deltaTime);

                this.currentDayTime -= _deltaTime;

                if (this.currentDayTime <= 0f)
                {
                    this.currentDay++;

                    currentDayTime = DataBase_Manager.Instance.test.dayPassTime;

                    dayPassObserver.Notify_Func(this.currentDay);
                }
            }

            yield return null;
        }
    }

    public void Pause_Func()
    {
        isTimeRunning = false;
    }

    public void Subscribe_Func(Action<float> _del)
    {
        this.timeRunningObserver.Subscribe_Func(_del);
    }
    public void Subscribe_DayPass_Func(Action<int> _del)
    {
        this.dayPassObserver.Subscribe_Func(_del);
    }

    public void Remove_Func(Action<float> _del)
    {
        this.timeRunningObserver.Remove_Func(_del);
    }
    public void Remove_DayPass_Func(Action<int> _del)
    {
        this.dayPassObserver.Remove_Func(_del);
    }

    public void CallBtn_Play_Func()
    {
        TimePlay_Func();
    }

    public void TimePlay_Func()
    {
        if (isTimeRunning == false)
        {
            isTimeRunning = true;
      text.text = "시간정지";
        }
        else
        {
            isTimeRunning = false;
      text.text = "시간재생";
    }
    }
}