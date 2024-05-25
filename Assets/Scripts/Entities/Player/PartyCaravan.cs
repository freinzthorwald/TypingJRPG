using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
 * My suspicion in creating this class is that the collective travelling party will be an entirely different object from the individual party members who will appear in combat scenes.
 */
public class PartyCaravan
{
    public static PartyCaravan Instance { get; private set; } //I see no reason to have a second one of these ever
    private int Health = 100; //We're going to make the assumption the party has a max of 100 health all the time.

    private PartyCaravan()
    {
    }

    public static void CreateInstance()
    {
        Instance = new PartyCaravan();
    }

    /* If nothing else, set health to max, or 100. Whatever. */
    public void StartTravel()
    {
        Health = 100;
        TravelManager.instance.ModifyHealthBar(Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        TravelManager.instance.ModifyHealthBar(Health);
    }

    public bool IsDead()
    {
        if(Health < 1)
        {
            return true;
        }
        return false;
    }
}
