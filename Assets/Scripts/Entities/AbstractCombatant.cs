using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractCombatant : MonoBehaviour
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public int HealthFatigue; //Temp name for max health loss, which may or may not be a thing
    public int Mental;
    public int MaxMental;
    public int MentalFatigue; //Name for max mental loss, which will likely be a thing
    private float TurnTimer;
    private float ActionTimer;
    public int Speed;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health < 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        
    }

    public void UpdateTurnTimer()
    {
        //Current logic is a character should get Speed per Second.
        //You get to act when you build up 100 Turn Points
        if(TurnTimer < 100)
        {
            TurnTimer += Speed * Time.deltaTime;
        }
        if(TurnTimer >= 100)
        {
            TurnTimer = 100;
            TurnReady();
        }
    }

    protected abstract void TurnReady();
}
