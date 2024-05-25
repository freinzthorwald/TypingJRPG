using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class EnemyScriptableObject : ScriptableObject
{
    public string displayName;
    public int health;
    public int power;
}
