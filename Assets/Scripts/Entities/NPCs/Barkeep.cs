using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barkeep : AbstractNpc
{
    public Barkeep()
    {
        Topics = new Dictionary<string, string>();
        Topics.Add("AAAAA", "What're you having?");
        Topics.Add("Name", "Name is Geoffrey, used to be a fighter.");
        Topics.Add("Job", "Used to be a fighter, now I'm just a barkeep. Hear a lot working here, mages tend to talk a lot.");
        Topics.Add("Mage", "Yeah, they like to sit down, have a drink, and talk about the magic they know. Seems like a competition a lot of the time.");
        Topics.Add("Mages", "Yeah, they like to sit down, have a drink, and talk about the magic they know. Seems like a competition a lot of the time.");
        Topics.Add("Magic", "I've heard a thing a thing or two about it, never could use it myself. Magnus means big and makes your spell bigger. If they say so.");
        Topics.Add("ZZZZZ", "Sorry, I've heard a lot of things as a barkeep but never heard about that.");
        Topics.Add("Bye", "Take care, don't get yourself killed.");
    }
    
    public override void Talk(string topic)
    {
        if(Topics.ContainsKey(topic))
        {
            TextBoxSingleton.instance.OutputBox.text = Topics[topic];
        }
        else
        {
            TextBoxSingleton.instance.OutputBox.text = Topics["ZZZZZ"];
        }
        if(topic.Equals("Magic"))
        {
            StateController.instance.hero.Learn("Magnus");
        }
        if(topic.Equals("Bye"))
        {
            StateController.instance.ChangeState(new IdleState());
        }
    }
}
