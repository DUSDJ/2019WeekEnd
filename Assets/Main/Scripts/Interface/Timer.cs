using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public interface IHasTimer
{
    void SetTimer(float endTime);
    void AddTick(float tick);
}

public class Timer : MonoBehaviour, IHasTimer
{
    public float maxTime;
    private float _elapsedTime;

    public Text timerText;

    public void SetTimer(float endTime)
    {
        maxTime = endTime;
    }

    public void AddTick(float tick)
    {
        _elapsedTime += tick;

        timerText.text = (_elapsedTime / maxTime).ToString();
    }

}
