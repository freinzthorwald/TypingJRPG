using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Words", menuName = "ScriptableObjects/Words/PrefixScriptableObject", order = 1)]
public class PrefixScriptableObject : AbstractWordScriptableObject
{
    public int PowerPercent;
    public int MentalCostPercent;
}
