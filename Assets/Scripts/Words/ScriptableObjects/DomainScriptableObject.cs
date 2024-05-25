using Assets.Scripts.Words.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DomainWord", menuName = "ScriptableObjects/Words/DomainScriptableObject", order = 3)]
public class DomainScriptableObject : AbstractWordScriptableObject
{
    public DomainsEnum Domain;
}
