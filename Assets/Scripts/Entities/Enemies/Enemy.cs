using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractCombatant
{
    public int Power;

    public void Setup()
    {
        Name = "Commie Pinko";
        Health = 50;
        Power = 10;
        Speed = 20;
    }

    public void Setup(EnemyScriptableObject template)
    {
        Name = template.displayName;
        Health = template.health;
        Power = template.power;
    }

    protected override void TurnReady()
    {
        TempAttack(Power, 0); //Enemy will just attack the first person in the party, or EmCee.
    }

    public void TempAttack(int power, int targetNumber)
    {
        //Party.Instance.ActiveParty[targetNumber].TakeDamage(power);
        TextBoxSingleton.instance.OutputBox.text = Name + " dealt " + power.ToString() + " damage.";
    }
}