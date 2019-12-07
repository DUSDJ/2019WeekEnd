using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Main.Scripts;

public class TimeManager : Singleton<TimeManager>
{
    public float tick;
    public List<GameObject> timerObjects;

    public bool isPlay = false;

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Gaming)
            return;

        tick = Time.deltaTime;
        for (int ix = 0; ix < timerObjects.Count; ix++)
        {
            timerObjects[ix].GetComponent<IHasTimer>().AddTick(tick);
        }
    }

    public void AddTimer(GameObject timerObject)
    {
        if (timerObjects.Contains(timerObject))
            return;

        timerObjects.Add(timerObject);
    }

    public void ControllAllTimer()
    {
        isPlay =! isPlay;
        if (isPlay)
        {
            GameManager.Instance.GameState = GameState.Gaming;
        }
        else
        {
            GameManager.Instance.GameState = GameState.Pause;
        }
    }
}
