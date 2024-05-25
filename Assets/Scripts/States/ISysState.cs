using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISysState
{
    public void Parse(string input);
    public void KeyPress(KeyCode keyCode);
    public void OnEnter();
    public void OnExit();
}
