using UnityEngine;
using System.Collections;

public enum ParameterType
{
    None,
    StressIncrease,
    StressDecrease,
    ParameterTypeCount
}

public class CounselSelectionParameter
{
    public ParameterType parameterType;
    public int parameterValue;
}
