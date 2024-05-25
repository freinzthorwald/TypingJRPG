using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractNpc
{
    protected string Name;
    protected Dictionary<String, String> Topics;
    
    public abstract void Talk(string topic);
}
