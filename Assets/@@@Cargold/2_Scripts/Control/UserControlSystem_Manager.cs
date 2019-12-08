using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlSystem_Manager : MonoBehaviour
{
    public static UserControlSystem_Manager Instance;

    private ControlState controlState;

    public ControlState CurrentControlState { get => controlState; }

    public IEnumerator Init_Cor()
    {
        Instance = this;

        yield break;
    }

    public void GameStart_Func()
    {
        controlState = ControlState.MainField;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            switch (controlState)
            {
                case ControlState.MainField:
                    TimeSystem_Manager.Instance.TimePlay_Func();
                    break;

                case ControlState.Guild_Activate:
                    GuildSystem_Manager.Instance.HiredselectedHero_Func();
                    break;

                default:
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            switch (controlState)
            {
                case ControlState.MainField:
                    TimeSystem_Manager.Instance.Pause_Func();
                    break;

                case ControlState.Guild_Activate:
                    GuildSystem_Manager.Instance.Deactivate_Func();
                    break;

                case ControlState.Dungeon_Activate:
                case ControlState.Dungeon_SlotSelected:
                    DungeonInfoView.Instance.Deactivate_Func();
                    break;

                case ControlState.Dungeon_Result:
                    DungeonResultView.Instance.Deactivate_Func();
                    break;

                case ControlState.HeroInfo_Activate:
                    HeroInfoManager.Instance.Hide();
                    break;

                default:
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.W) == true)
        {
            switch (this.controlState)
            {
                case ControlState.MainField:
                    break;

                case ControlState.Guild_Activate:
                    GuildSystem_Manager.Instance.SelectedMarkMove_Func(Input.GetKeyDown(KeyCode.S) == true);
                    break;

                case ControlState.Dungeon_Activate:
                    break;

                case ControlState.Dungeon_SlotSelected:
                    break;

                default:
                    break;
            }
        }
    }

    public void SetState_Func(ControlState _controlState)
    {
        this.controlState = _controlState;
    }

    public void CallBtn_Touch_Func()
    {
        switch (this.CurrentControlState)
        {
            case ControlState.HeroInfo_Activate:
                HeroInfoManager.Instance.Hide();
                UI_HeroList_Manager.Instance.DeselectedElem_Func();
                break;

            case ControlState.MainField:
                break;
            case ControlState.Guild_Activate:
                GuildSystem_Manager.Instance.Deactivate_Func();
                break;

            case ControlState.Dungeon_Activate:
            case ControlState.Dungeon_SlotSelected:
                DungeonInfoView.Instance.Deactivate_Func();
                break;

            case ControlState.Dungeon_Result:
                DungeonResultView.Instance.Deactivate_Func();
                break;
            
            case ControlState.Counsel_Activate:
                break;

            default:
                break;
        }
    }

    public enum ControlState
    {
        MainField,

        Guild_Activate,

        Dungeon_Activate,
        Dungeon_SlotSelected,

        Dungeon_Result,

        HeroInfo_Activate,
        Counsel_Activate,
    }
}
