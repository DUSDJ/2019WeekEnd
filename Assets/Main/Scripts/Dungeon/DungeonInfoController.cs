using UnityEngine;
using System.Collections;

public static class DungeonInfoController
{
    public static DungeonInfoView view;

    public static void UpdateView(FieldDungeon_Script.DungeonData dungeonData)
    {
        view.UpdateView(dungeonData);
    }

    public static void UpdateAverageStress()
    {
        view.UpdateAverageStress();
    }
}
