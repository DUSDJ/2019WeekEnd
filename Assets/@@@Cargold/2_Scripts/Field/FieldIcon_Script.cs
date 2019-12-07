using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold.ObjectPool;
using static FieldSystem_Manager;

public class FieldIcon_Script : MonoBehaviour, IGeneratedByPoolingSystem
{
    [SerializeField] private FieldIconType fieldIconType;

    public FieldIconType FieldIconType { get => fieldIconType; }

    public virtual void Init_Func()
    {

    }

    public void CallBtn_Selected_Func()
    {
        FieldSystem_Manager.Instance.SelectedIcon_Func(this);
    }

    void IGeneratedByPoolingSystem.CallI_GenerateByPoolingSystem_Func()
    {
        this.Init_Func();
    }
}
