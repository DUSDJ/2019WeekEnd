using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : MonoBehaviour
{
    public static Karma Instance;

    public string[] nun;
    public string[] pirate;
    public string[] babarian;
    public string[] knight;
    public string[] dwarf;
    public string[] normal;

    private void Awake()
    {
        Instance = this;
    }

    public string[] GetKarmas(HeroType job, int count = 2)
    {
        string[] container = new string[count];
        string[] temp = new string[count-1];
        switch (job)
        {
            case HeroType.Priest:
            case HeroType.Nun:
                temp = nun.GetRandomPick_Func(count-1);
                break;

            case HeroType.BarbarianW:
            case HeroType.Barbarian:
                temp = babarian.GetRandomPick_Func(count - 1);
                break;

            case HeroType.Pirate:
            case HeroType.PirateW:
                temp = pirate.GetRandomPick_Func(count - 1);
                break;
                
            case HeroType.Drawf:
                temp = dwarf.GetRandomPick_Func(count - 1);
                break;

            case HeroType.Knight:
                temp = knight.GetRandomPick_Func(count - 1);
                break;
        }

        for (int ix = 0; ix < count - 1; ix++)
            container[ix] = temp[ix];

        container[count - 1] = normal.GetRandItem_Func();

        return container;
    }
}
