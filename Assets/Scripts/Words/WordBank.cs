using Assets.Scripts.Words;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WordBank
{
    public static WordBank Instance { get; private set; }
    public Dictionary<string, AbstractWord> WordDictionary { get; private set; }

    public static void CreateInstance()
    {
        Instance = new WordBank();
    }

    private WordBank()
    {
        WordDictionary = new Dictionary<string, AbstractWord>();
        AddCoreWords();
        AddPrefixWords();
        AddDomainWords();
    }

    private void AddCoreWords()
    {
        CoreWordScriptableObject[] coreWordObjects = Resources.LoadAll<CoreWordScriptableObject>("ScriptableObjects/Core");
        foreach (CoreWordScriptableObject coreWordObject in coreWordObjects)
        {
            WordDictionary[coreWordObject.Word] = new CoreWord(coreWordObject);
        }
    }

    private void AddPrefixWords()
    {
        PrefixScriptableObject[] prefixObjects = Resources.LoadAll<PrefixScriptableObject>("ScriptableObjects/Prefixes");
        foreach (PrefixScriptableObject prefixObject in prefixObjects)
        {
            WordDictionary[prefixObject.Word] = new Prefix(prefixObject);
        }
    }

    private void AddDomainWords()
    {
        DomainScriptableObject[] domainWordObjects = Resources.LoadAll<DomainScriptableObject>("ScriptableObjects/Domain");
        foreach (DomainScriptableObject domainWordObject in domainWordObjects)
        {
            WordDictionary[domainWordObject.Word] = new DomainWord(domainWordObject);
        }
    }

    public enum Segments
    {
        PREFIX,
        CORE,
        DOMAIN
    }
}
