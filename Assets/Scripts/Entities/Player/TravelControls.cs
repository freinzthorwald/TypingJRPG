using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class TravelControls : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            KeyCode code = ValidKeyCodes();
            if (!String.IsNullOrEmpty(Input.inputString))
            {
                TravelManager.instance.Parse(Input.inputString);
            }
            else if(code != KeyCode.A)
            {
                TravelManager.instance.KeyPress(code);
            }
        }
    }

    private KeyCode ValidKeyCodes()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            return KeyCode.DownArrow;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            return KeyCode.UpArrow;
        }
        return KeyCode.A; //We're returning A because A should be caught by inputString so it should never be tested here. It's a shitfix.
    }
}