using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightState : ISysState
{
    private Enemy target;

    public FightState()
    {
        
    }

    public void KeyPress(KeyCode keyCode)
    {
        //Does nothing, honestly, I don't even want this method to exist.
    }

    public void OnEnter()
    {
        TextBoxSingleton.instance.OutputBox.text = $"You encounter a {target.Name}";
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
                Cast(inputBox.text);
                inputBox.text = string.Empty;
            }
        }
    }

    private void Cast(string phrase)
    {
        TyperHero hero = StateController.instance.hero;
        Text outputBox = TextBoxSingleton.instance.OutputBox;
        string[] words = phrase.Split(' ');
        string spellWords = hero.ParseSpellWords(words);
        SpellScriptableObject spell = WordBankSingleton.Instance.Cast(spellWords); //This can return a delay for turn order stuff, but at present we don't actually care.
        if(spell != null)
        {
           // hero.ManaCost(spell.cost);
            target.Health -= spell.power;
            outputBox.text = "You cast " + spell.castText + " and dealt " + spell.power + " damage.";
            if(target.Health <= 0)
            {
                outputBox.text = outputBox.text + "\nYou have defeated " + target.Name;
                StateController.instance.ChangeState(new IdleState());
            }
            else
            {
                outputBox.text = outputBox.text + "\nYou were hit for " + target.Power + " damage.";
            //    hero.TakeDamage(target.Power);
            }
        }
    }
}
