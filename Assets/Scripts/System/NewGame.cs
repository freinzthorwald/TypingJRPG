using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject PartyPrefab;

    public void InitializeGame()
    {
        InitializeParty();
        PartyCaravan.CreateInstance();
    }

    private void InitializeParty()
    {
        GameObject party = Instantiate(PartyPrefab);
        party.transform.parent = this.gameObject.transform;
    }
}
