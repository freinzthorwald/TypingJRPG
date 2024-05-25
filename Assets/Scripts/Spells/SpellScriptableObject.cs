using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "ScriptableObjects/SpellScriptableObject", order = 2)]
public class SpellScriptableObject : ScriptableObject
{
    public string spellWords;
    public string castText;
    public float delay;
    public int cost;
    public int power;
}
