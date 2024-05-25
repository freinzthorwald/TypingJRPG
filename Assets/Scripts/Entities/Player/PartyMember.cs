using Assets.Scripts.Words;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartyMember : AbstractCombatant
{
    private Dictionary<string, AbstractWord> WordsKnown { get; set; } //Going to leave this here, this is what I would like to use

    public void Setup(PartyMemberScriptableObject scriptableObject)
    {
        this.Name = scriptableObject.Name;
        this.MaxHealth = scriptableObject.MaxHealth;
        this.Health = this.MaxHealth;
        this.MaxMental = scriptableObject.MaxMental;
        this.Mental = this.MaxMental;
        this.Speed = scriptableObject.Speed;
        WordsKnown = new Dictionary<string, AbstractWord>();
        foreach(string word in scriptableObject.KnownWords)
        {
            if(WordBank.Instance.WordDictionary.ContainsKey(word))
            {
                WordsKnown[word] = WordBank.Instance.WordDictionary[word];
            }
        }
    }

    protected override void TurnReady()
    {
        throw new System.NotImplementedException();
    }
}
