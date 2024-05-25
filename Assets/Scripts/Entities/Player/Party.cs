using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public GameObject MemberPrefab;
    [SerializeField]//This doesn't really need to be serialized, but it lets us view it in the inspector
    public PartyMember[] ActiveParty { get; private set; }

    [SerializeField]//This doesn't really need to be serialized, but it lets us view it in the inspector
    public List<PartyMember> FullRoster { get; private set; }

    public void Awake()
    {
        ActiveParty = new PartyMember[4];
        FullRoster = new List<PartyMember>();
        PartyMemberScriptableObject partyMemberScriptableObject = Resources.Load<PartyMemberScriptableObject>("ScriptableObjects/PartyMembers/Emcee");
        GameObject characterObject = Instantiate(MemberPrefab);
        PartyMember mainCharacter = characterObject.GetComponent<PartyMember>();
        mainCharacter.Setup(partyMemberScriptableObject);
        AddMember(mainCharacter);
        SetActiveMember(mainCharacter, 0);
        mainCharacter.gameObject.transform.parent = this.gameObject.transform;
        /* We won't create the second party member yet
        partyMemberScriptableObject = Resources.Load<PartyMemberScriptableObject>("ScriptableObjects/PartyMembers/Day Mo");
        PartyMember demoCharacter = new PartyMember(partyMemberScriptableObject);
        Party.Instance.AddMember(demoCharacter);
        Party.Instance.SetActiveMember(demoCharacter, 1);
        */
    }

    public void AddMember(PartyMember member)
    {
        FullRoster.Add(member);
    }

    public void RemoveMember(PartyMember member) 
    { 
        FullRoster.Remove(member);
    }

    public void SetActiveMember(PartyMember member, int slot)
    {
        ActiveParty[slot] = member;
    }

    public bool HasActiveMembers()
    {
        for(int slot = 0; slot < ActiveParty.Length; slot++)
        {
            if (ActiveParty[slot] != null)
            {
                return true;
            }
        }
        return false;
    }
}