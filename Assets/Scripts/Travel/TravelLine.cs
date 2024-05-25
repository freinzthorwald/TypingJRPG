using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public class TravelLine : MonoBehaviour
{
    private TravelLineData lineData;
    private Text textBox;
    private bool activeFlag;
/*These are the variables used to store the actual type comparison values*/
    private string line;
    private int charIndex;
/*These are the variables used to store the text displayed to the player*/
    private string displayLine;
    private int displayIndex;
    private List<Color> colorList;
/*This should be somewhere else, but it doesn't exist yet. */
    private float hits = 4;

    private void Awake()
    {
        if(textBox == null)
        {
            if(!TryGetComponent(out textBox))
            {
                Debug.LogError("Could not find textbox component.");
            }
        }
        colorList = new List<Color>();
    }

    public void Init(TravelLineData data)
    {
        lineData = data;
        line = new string(data.Phrase);
        displayLine = new string(data.Phrase);
        textBox.text = data.Phrase;
        textBox.rectTransform.localPosition = new UnityEngine.Vector3(data.XPosition,data.YPosition,0);
        activeFlag = true;
        for(int counter = 0; counter < displayLine.Length; counter++)
        {
            colorList.Add(new Color(0, 0, 0));
        }
    }

    public void Parse(char c)
    {
        if (!string.IsNullOrEmpty(line))
        {
            if (c.Equals(line[charIndex]))
            {
                displayLine = ColorDisplayText(true);
                textBox.text = displayLine;
                charIndex++;
            }
            else
            {
                PartyCaravan.Instance.TakeDamage(1);
                displayLine = ColorDisplayText(false);
                textBox.text = displayLine;
                if (colorList[charIndex].r == 1)
                {
                    PartyCaravan.Instance.TakeDamage(4);
                    charIndex++;
                }
            }
        }
    }

    public bool IsLineComplete()
    {
        if (charIndex >= line.Length)
        {
            activeFlag = false;
            colorList.Clear();
            charIndex = 0;
            textBox.text = "";
            return true;
        }
        return false;
    }

    public bool IsActive()
    {
        return activeFlag;
    }

    private void Update()
    {
        if(lineData != null)
        {
            textBox.rectTransform.localPosition += new UnityEngine.Vector3(-lineData.Speed * Time.deltaTime, 0, 0);
        }
    }

    private string ColorDisplayText(bool isCorrect)
    {
        Color color = colorList[charIndex];
        string newLine = "";
        if (isCorrect)
        {
            color.g = 1;
        }
        else
        {
            color.r += 1 / hits;
            if(color.r >= 1)
            {
                color.r = 1;
            }
        }
        colorList[charIndex] = color;
        for(int counter = 0; counter < line.Length; counter++)
        {
            newLine += $"<color=#{ColorUtility.ToHtmlStringRGB(colorList[counter])}>";
            newLine += line[counter];
            newLine += "</color>";
        }
        return newLine;
    }
}