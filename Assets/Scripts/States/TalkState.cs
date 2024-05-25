using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkState : ISysState
{
    private AbstractNpc npc;
    public TalkState(AbstractNpc target)
    {
        npc = target;
    }

    public void KeyPress(KeyCode keyCode)
    {
        //Does nothing, honestly, I don't even want this method to exist.
    }

    public void OnEnter()
    {
        npc.Talk("AAAAA");
    }

    public void OnExit()
    {
        
    }

    public void Parse(string input)
    {
        Text inputBox = TextBoxSingleton.instance.InputBox;
        foreach(char c in input)
        {
            if(Char.IsLetter(c) || c == ' ')
            {
                inputBox.text = inputBox.text + c;
            }
            else if(c == '\b' && TextBoxSingleton.instance.InputBox.text.Length > 0) //Back Space apparently
            {
                inputBox.text = inputBox.text.Remove(inputBox.text.Length - 1, 1);
            }
            else if(c == '\n' || c == '\r')
            {
                ParseLine(inputBox.text);
                inputBox.text = string.Empty;
            }
        }
    }

    private void ParseLine(string input)
    {
        npc.Talk(input);
    }
}
