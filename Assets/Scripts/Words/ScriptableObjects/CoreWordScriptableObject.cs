using Assets.Scripts.Words.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoreWord", menuName = "ScriptableObjects/Words/CoreScriptableObject", order = 2)]
public class CoreWordScriptableObject : AbstractWordScriptableObject
{
    public int MentalCost;
}
