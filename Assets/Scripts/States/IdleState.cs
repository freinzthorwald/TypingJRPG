using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IdleState : ISysState
{
    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void KeyPress(KeyCode keyCode)
    {
        //Does nothing, honestly, I don't even want this method to exist.
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
        string line = input;
        int index = line.IndexOf(' ');
        if(index == -1)
        {
            index = line.Length;
        }
        string firstWord = line.Substring(0, index);
        if(firstWord.Equals("Fight"))
        {
            StateController.instance.ChangeState(new FightState());
        }
        else if(firstWord.Equals("Talk"))
        {
            StateController.instance.ChangeState(new TalkState(new Barkeep()));
        }
        else if(firstWord.Equals("Rest"))
        {
            //Go through each party member and fully heal them or something
        }
        else if(firstWord.Equals("Travel"))
        {
            TextBoxSingleton.instance.OutputBox.text = "";
            StateController.instance.ChangeState(new TravelState(TravelManager.instance.Destination));
        }
        else
        {
            TextBoxSingleton.instance.OutputBox.text = firstWord + " is not a valid command!";
        }
    }
}
