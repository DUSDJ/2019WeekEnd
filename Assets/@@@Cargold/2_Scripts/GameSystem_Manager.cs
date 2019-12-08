using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    public static GameSystem_Manager Instance;

    public GuildSystem_Manager guildSystem_Manager;
    public UserSystem_Manager userSystem_Manager;
    public DataBase_Manager dataBase_Manager;
    public TimeSystem_Manager timeSystem_Manager;
    public FieldSystem_Manager fieldSystem_Manager;
    public SoundManager soundManager;
    public DungeonInfoView dungeonInfoView;
    public UserControlSystem_Manager userControlSystem_Manager;
    public DungeonResultView dungeonResultView;

    public UI_Time_Manager uI_Time_Manager;
    public UI_Atmo_Manager uI_Atmo_Manager;
    public UI_Bottom_Resource_Manager uI_Bottom_Resource_Manager;
    public UI_HeroList_Manager uI_HeroList_Manager;

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
        yield return uI_Time_Manager.Init_Cor(0);
        yield return uI_Atmo_Manager.Init_Cor();
        yield return uI_Bottom_Resource_Manager.Init_Cor(0);
        yield return userSystem_Manager.Init_Cor(0);
        yield return uI_HeroList_Manager.Init_Cor();
        yield return fieldSystem_Manager.Init_Cor(0);
        yield return soundManager.InitializeCoroutine();
        yield return dungeonInfoView.Init_Cor();
        yield return userControlSystem_Manager.Init_Cor();
        yield return dungeonResultView.Init_Cor();

        yield return guildSystem_Manager.Init_Cor(1);
        yield return uI_Time_Manager.Init_Cor(1);
        yield return uI_Bottom_Resource_Manager.Init_Cor(1);
        yield return userSystem_Manager.Init_Cor(1);
        yield return fieldSystem_Manager.Init_Cor(1);

        TimeSystem_Manager.Instance.Activate_Func();
        FieldSystem_Manager.Instance.Activate_Func();
        UserControlSystem_Manager.Instance.GameStart_Func();

        yield break;
    }
}