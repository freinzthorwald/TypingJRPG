using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSingleton : MonoBehaviour
{
    public static NpcSingleton instance {get; private set;}
    public List<AbstractNpc> npcList;
    public Dictionary<String, AbstractNpc> npcBank = new Dictionary<string, AbstractNpc>();
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        /*
        foreach(AbstractNpc npc in npcList)
        {
            npcBank.Add(npc.Name, npc);
        }
        */
    }
}
