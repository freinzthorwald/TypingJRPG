using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Player/PartyMemberScriptableObject", order = 1)]
public class PartyMemberScriptableObject : ScriptableObject
{
    public string Name;
    public int MaxHealth;
    public int MaxMental;
    public int Speed;
    public List<string> KnownWords;
}
