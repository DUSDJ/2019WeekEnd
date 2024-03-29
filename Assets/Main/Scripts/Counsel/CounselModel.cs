﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class CounselModel
{
    public ICharacter Hero;

    public string Title;
    public string Body;
    public string[] Selections;
    public CounselSelectionParameter[] SelectionParams;
}



