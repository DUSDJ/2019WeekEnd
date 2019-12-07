using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    public static GameSystem_Manager Instance;

    public GuildSystem_Manager guildSystem_Manager;    
    public DataBase_Manager dataBase_Manager;
    public TimeSystem_Manager timeSystem_Manager;

    private void Awake()
    {
        Instance = this;

        StartCoroutine(Init_Cor());
    }

    private IEnumerator Init_Cor()
    {
        yield return dataBase_Manager.Init_Cor();
        yield return guildSystem_Manager.Init_Cor(0);
        yield return timeSystem_Manager.Init_Cor();

        yield return guildSystem_Manager.Init_Cor(1);

        TimeSystem_Manager.Instance.Activate_Func();

        yield break;
    }
}