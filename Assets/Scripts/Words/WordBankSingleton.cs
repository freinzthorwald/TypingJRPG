using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBankSingleton : MonoBehaviour
{
    public static WordBankSingleton Instance {get; private set; }
    public Text outputBox = null;
    public List<AbstractWordScriptableObject> wordObjects = null;
    public List<SpellScriptableObject> spellObjects = new List<SpellScriptableObject>();
    private Dictionary<string, AbstractWordScriptableObject> wordBank = new Dictionary<string, AbstractWordScriptableObject>();
    private Dictionary<string, SpellScriptableObject> spellBank = new Dictionary<string, SpellScriptableObject>();

    void Awake()
    {
        Instance = this;
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        foreach(AbstractWordScriptableObject word in wordObjects)
        {
            wordBank.Add(word.Word, word);
        }
        foreach(SpellScriptableObject spell in spellObjects)
        {
            spellBank.Add(spell.spellWords, spell);
        }
        outputBox = TextBoxSingleton.instance.OutputBox;
        /*
        LearnableWordScriptableObject[] wordList = FindObjectsOfType<LearnableWordScriptableObject>();
        foreach(LearnableWordScriptableObject word in wordList)
        {
            wordBank.Add(word.word, word);
        }
        */
    }

    public bool Learn(String word)
    {
        if(wordBank.ContainsKey(word))
        {
            outputBox.text = "You learned " + wordBank[word].Translation + "!";
            return true;
        }
        else
        {
            outputBox.text = "That is not a word";
        }
        return false;
    }

    public SpellScriptableObject Cast(String spell)
    {
        if(spellBank.ContainsKey(spell))
        {
            outputBox.text = spellBank[spell].castText;
            return spellBank[spell];
        }
        else
        {
            outputBox.text = "That isn't a spell";
        }
        return null;
    }
}
