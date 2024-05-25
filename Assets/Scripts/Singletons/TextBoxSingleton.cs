using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxSingleton : MonoBehaviour
{
    public static TextBoxSingleton instance {get; private set;}
    public Text InputBox;
    public Text OutputBox;
    void Awake()
    {
        instance = this;
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
    }
}