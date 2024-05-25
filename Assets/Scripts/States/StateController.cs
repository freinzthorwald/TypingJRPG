using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class StateController : MonoBehaviour
{
    public static StateController instance {get; private set;}
    private ISysState currentState = new IdleState();
    public TyperHero hero;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ChangeState(ISysState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

    public void ParseLetters(string input)
    {
        currentState.Parse(input);
    }

    public void KeyPress(KeyCode keyCode)
    {
        currentState.KeyPress(keyCode);
    }
}
