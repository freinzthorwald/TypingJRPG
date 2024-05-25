using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Travel", menuName = "ScriptableObjects/Travel", order = 4)]
public class TravelScriptableObject : ScriptableObject
{
    public List<TravelLineData> TravelLines;
}
