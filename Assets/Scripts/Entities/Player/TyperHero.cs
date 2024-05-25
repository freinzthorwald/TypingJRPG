using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static UnityEngine.GraphicsBuffer;

public class TyperHero : MonoBehaviour
{
    public Text manaBox = null;
    private string currentSpell = string.Empty;
    private List<String> knownWords = new List<string>();
    private float delay = 0;
    private int maxMana = 100;
    private int currentMana = 100;
    private int maxHealth = 100;
    private int currentHealth = 100;
    public BattleManager BattleManager;


    void Start()
    {
        //UpdateManaBox(Party.Instance.ActiveParty[0]);
        //knownWords.Add("Ignis");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if (!String.IsNullOrEmpty(Input.inputString))
            {
                Parse(Input.inputString);
            }
        }
    }

    public void Learn(string word)
    {
        if(knownWords.Contains(word))
        {
           // outputBox.text = "You already know that word!";
        }
        else
        {
            knownWords.Add(word);
            TextBoxSingleton.instance.OutputBox.text = TextBoxSingleton.instance.OutputBox.text + "\nYou learned " + word;
        }
    }

    public string ParseSpellWords(string[] words)
    {
        string spellWords = string.Empty;
        foreach(string word in words)
        {
            if(knownWords.Contains(word))
            {
                if(spellWords.Length == 0)
                {
                    spellWords = word;
                }
                else
                {
                    spellWords = spellWords + " " + word;
                }
            }
        }
        return spellWords;
    }

    public void UpdateManaBox(PartyMember character)
    {
        manaBox.text = "Health: " + character.Health + "/" + character.MaxHealth + "\n" + "Mana: " + character.MaxMental + "/" + character.MaxMental;
    }

    public void Rest()
    {
        currentHealth += 10;
        currentMana += 10;
    }

    public void Parse(string input)
    {
        Text inputBox = TextBoxSingleton.instance.InputBox;
        foreach (char c in input)
        {
            if (Char.IsLetter(c) || c == ' ')
            {
                inputBox.text = inputBox.text + c;
            }
            else if (c == '\b' && TextBoxSingleton.instance.InputBox.text.Length > 0) //Back Space apparently
            {
                inputBox.text = inputBox.text.Remove(inputBox.text.Length - 1, 1);
            }
            else if (c == '\n' || c == '\r')
            {
                Cast(inputBox.text);
                inputBox.text = string.Empty;
            }
        }
    }

    private void Cast(string phrase)
    {
        Text outputBox = TextBoxSingleton.instance.OutputBox;
        string[] words = phrase.Split(' ');
        string spellWords = ParseSpellWords(words);
        SpellScriptableObject spell = WordBankSingleton.Instance.Cast(spellWords); //This can return a delay for turn order stuff, but at present we don't actually care.
        if (spell != null)
        {
            //ManaCost(spell.cost);
            BattleManager.Enemies[0].Health -= spell.power;
            outputBox.text = "You cast " + spell.castText + " and dealt " + spell.power + " damage.";
            if (BattleManager.Enemies[0].Health <= 0)
            {
                outputBox.text = outputBox.text + "\nYou have defeated " + BattleManager.Enemies[0].Name;
                StartCoroutine(LoadScene());
            }
            else
            {
                outputBox.text = outputBox.text + "\nYou were hit for " + BattleManager.Enemies[0].Power + " damage.";
                //TakeDamage(BattleManager.Instance.Enemies[0].Power);
            }
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EventSelection");
    }
}