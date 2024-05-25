using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleton
{
    public static EnemySingleton Instance {get; private set;}
    public EnemyScriptableObject victim;
 
}
