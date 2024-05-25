using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelState : ISysState
{
    public TravelQuest quest;
    private int phraseIndex = 0;

    public TravelState(TravelScriptableObject destination)
    {
     //   quest = TravelManager.instance.StartQuest(destination);
    }

    public void KeyPress(KeyCode keyCode)
    {
        quest.KeyPress(keyCode);
    }

    public void OnEnter()
    {
    
    }

    public void OnExit()
    {

    }

    public void Parse(string input)
    {
        string phrase = TextBoxSingleton.instance.OutputBox.text;
        foreach(char c in input)
        {
            quest.Parse(c);
            if (quest.IsQuestComplete())
            {
                TextBoxSingleton.instance.OutputBox.text = "Journey finished!";
                StateController.instance.ChangeState(new IdleState());
                TravelManager.instance.FinishQuest();
            }
            else if(PartyCaravan.Instance.IsDead())
            {
                TextBoxSingleton.instance.OutputBox.text = "Journey failed :(";
                StateController.instance.ChangeState(new IdleState());
                TravelManager.instance.FinishQuest();
            }
        }
    }
}
